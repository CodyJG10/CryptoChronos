//SPDX-License-Identifier: MIT

pragma solidity ^0.8.10;

import "@openzeppelin/contracts/token/ERC721/IERC721Receiver.sol";
import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

import "./Interfaces/IERC2981Royalties.sol";

contract Auction is IERC721Receiver{
     
      enum State {
        ACTIVE, SOLD, CANCELLED
    }
    
    // static
    address public seller;
    uint256 public bidIncrement;
    uint256 public tokenId;
    address private nftAddress;
    address public operator;

    // state
    State public state;
    uint256 public highestBindingBid;
    address public highestBidder;
    mapping(address => uint256) public fundsByBidder;
    bool public ownerHasWithdrawn;

    // constants
    bytes4 private constant _INTERFACE_ID_ERC2981 = 0x2a55205a;

    event logBid(
        address bidder,
        uint256 bid,
        address highestBidder,
        uint256 highestBid,
        uint256 highestBindingBid);
    
    event stateChanged(State state);
     
    constructor(uint256 _bidIncrement, address _payTo, address _operator) {
        seller = _payTo;
        operator = _operator;
        bidIncrement = _bidIncrement;
    }

    function onERC721Received(address operator, address from, uint256 _tokenId, bytes calldata data ) public override returns (bytes4) {
        return this.onERC721Received.selector;
    }

    function depositNFT(address _NFTAddress, uint256 _TokenID) public onlyOperator {
        nftAddress = _NFTAddress;
        tokenId = _TokenID;
        ERC721(nftAddress).safeTransferFrom(msg.sender, address(this), tokenId);
        state = State.ACTIVE;
        emit stateChanged(state);
    }

    function getHighestBid() public view returns (uint256) {
        return fundsByBidder[highestBidder];
    }

    function placeBid()
        public
        payable
        onlyNotCanceled
        returns (bool success) {
        // reject payments of 0 ETH
        require(msg.value > 0);

        // calculate the user's total bid based on the current amount they've sent to the contract
        // plus whatever has been sent with this transaction
        uint256 newBid = fundsByBidder[msg.sender] + msg.value;

        // if the user isn't even willing to overbid the highest binding bid, there's nothing for us
        // to do except revert the transaction.
        require(newBid > highestBindingBid);

        // grab the previous highest bid (before updating fundsByBidder, in case msg.sender is the
        // highestBidder and is just increasing their maximum bid).
        uint256 highestBid = fundsByBidder[highestBidder];

        fundsByBidder[msg.sender] = newBid;

        if (newBid <= highestBid) {
            // if the user has overbid the highestBindingBid but not the highestBid, we simply
            // increase the highestBindingBid and leave highestBidder alone.

            // note that this case is impossible if msg.sender == highestBidder because you can never
            // bid less ETH than you've already bid.

            highestBindingBid = min(newBid + bidIncrement, highestBid);
        } else {
            // if msg.sender is already the highest bidder, they must simply be wanting to raise
            // their maximum bid, in which case we shouldn't increase the highestBindingBid.

            // if the user is NOT highestBidder, and has overbid highestBid completely, we set them
            // as the new highestBidder and recalculate highestBindingBid.

            if (msg.sender != highestBidder) {
                highestBidder = msg.sender;
                highestBindingBid = min(newBid, highestBid + bidIncrement);
            }
            highestBid = newBid;
        }

        emit logBid(
            msg.sender,
            newBid,
            highestBidder,
            highestBid,
            highestBindingBid
        );
        return true;
    }

    function min(uint256 a, uint256 b) private pure returns (uint256) {
        if (a < b) return a;
        return b;
    }

    function cancelAuction()
        public
        onlyOperator
        onlyNotCanceled
        returns (bool success) {
        state = State.CANCELLED;
        emit stateChanged(state);
        return true;
    }

    function withdraw() public returns (bool success) {
        address withdrawalAccount;
        uint256 withdrawalAmount;
        bool isSeller = false;

        if (state == State.CANCELLED) {
            // if the auction was canceled, everyone should simply be allowed to withdraw their funds
            withdrawalAccount = msg.sender;
            withdrawalAmount = fundsByBidder[withdrawalAccount];
        } else {
            // the auction finished without being canceled

            if (msg.sender == seller || msg.sender == operator) {
                // the auction's owner should be allowed to withdraw the highestBindingBid
                withdrawalAccount = highestBidder;
                withdrawalAmount = highestBindingBid;
                ownerHasWithdrawn = true;
                isSeller = true;
                state = State.SOLD;
                emit stateChanged(state);
                payoutToSeller(withdrawalAmount);
                ERC721(nftAddress).safeTransferFrom(address(this), highestBidder, tokenId);
                return true;
            } else if (msg.sender == highestBidder) {
                // the highest bidder should only be allowed to withdraw the difference between their
                // highest bid and the highestBindingBid
                withdrawalAccount = highestBidder;
                if (ownerHasWithdrawn) {
                    withdrawalAmount = fundsByBidder[highestBidder];
                } else {
                    withdrawalAmount =
                        fundsByBidder[highestBidder] -
                        highestBindingBid;
                }
            } else {
                // anyone who participated but did not win the auction should be allowed to withdraw
                // the full amount of their funds
                withdrawalAccount = msg.sender;
                withdrawalAmount = fundsByBidder[withdrawalAccount];
            }
        }

        require(withdrawalAmount > 0);

        fundsByBidder[withdrawalAccount] -= withdrawalAmount;

        payable(withdrawalAccount).transfer(withdrawalAmount);

        return true;
    }
  
    function checkRoyalties() internal returns (bool) {
        (bool success) = IERC165(nftAddress).supportsInterface(_INTERFACE_ID_ERC2981);
        return success;
    }

    function payoutToSeller(uint256 withdrawalAmount) public onlyOperator {
        // Handle royalties
        if(checkRoyalties()) {
            (address _receiver, uint256 _royaltyAmount) = IERC2981Royalties(nftAddress).royaltyInfo(tokenId, highestBindingBid);
            payable(_receiver).transfer(_royaltyAmount);
            payable(seller).transfer(withdrawalAmount - _royaltyAmount);
        }
        else {
            payable(seller).transfer(withdrawalAmount);
        }
    }

    modifier onlySeller() {
        require(msg.sender == seller);
        _;
    }

    modifier onlyNotSeller() {
        require(msg.sender != seller);
        _;
    }

    modifier onlyNotCanceled() {
        require(state != State.CANCELLED);
        _;
    }

    modifier onlyOperator() {
        require(msg.sender == operator);
        _;
    }
}