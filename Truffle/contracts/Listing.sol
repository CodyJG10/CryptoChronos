//SPDX-License-Identifier: MIT

pragma solidity ^0.8.10;

import "@openzeppelin/contracts/token/ERC721/IERC721Receiver.sol";
import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

import "./Interfaces/IERC2981Royalties.sol";

contract ListingEscrow is IERC721Receiver{

    // constants
    bytes4 private constant _INTERFACE_ID_ERC2981 = 0x2a55205a;

    enum State {
        ACTIVE, SOLD, CANCELLED
    }

    address private nftAddress;
    address payable public seller;
    uint public price;
    uint256 public tokenId;
    address private operator;

    State public state;
    event StateChanged(State _state);

    constructor(uint _price,
        address _seller,
        address _operator,
        uint256 _tokenId,
        address _nftAddress) {
        seller = payable(_seller);
        price = _price;
        tokenId = _tokenId;
        nftAddress = _nftAddress;
        operator = _operator;
    }

    function onERC721Received(address operator, address from, uint256 tokenId, bytes calldata data ) public override returns (bytes4) {
        return this.onERC721Received.selector;
    }

    function purchase() 
    public
    _isCorrectPrice
    payable {
        ERC721(nftAddress).safeTransferFrom(address(this), msg.sender, tokenId);
        uint amount = msg.value;
        if(checkRoyalties()) {
            (address _receiver, uint256 _royaltyAmount) = IERC2981Royalties(nftAddress).royaltyInfo(tokenId, amount);
            payable(_receiver).transfer(_royaltyAmount);
            seller.transfer(msg.value - _royaltyAmount);
        }
        else {
            seller.transfer(msg.value);
        }
        state = State.SOLD;
        emit StateChanged(state);
    }
    
    function depositNFT(address _NFTAddress, uint256 _TokenID)
        public
        _onlyOperator
    {
        nftAddress = _NFTAddress;
        tokenId = _TokenID;
        ERC721(nftAddress).safeTransferFrom(operator, address(this), tokenId);
        state = State.ACTIVE;
        emit StateChanged(state);
    }

       function checkRoyalties() internal returns (bool) {
        (bool success) = IERC165(nftAddress).supportsInterface(_INTERFACE_ID_ERC2981);
        return success;
    }
    
    function cancel()
        public
        _onlySeller
    {
        ERC721(nftAddress).safeTransferFrom(address(this), msg.sender, tokenId);
        state = State.CANCELLED;
        emit StateChanged(state);
    }

    modifier _onlySeller() {
        require(msg.sender == seller);
        _;
    }

    modifier _onlyOperator() {
        require(msg.sender == operator);
        _;
    }

    modifier _isCorrectPrice() {
        require(msg.value >= price, "Incorrect price");
        _;
    }
}