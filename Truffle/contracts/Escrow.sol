
//SPDX-License-Identifier: MIT
 
pragma solidity ^0.8.10;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/token/ERC721/IERC721Receiver.sol";

contract NftEscrow is IERC721Receiver {
    
    enum ProjectState { newEscrow, nftDeposited, cancelNFT, ethDeposited, canceledBeforeDelivery, deliveryInitiated, delivered }
    
    address payable public sellerAddress;
    address payable public buyerAddress;
    address public nftAddress;
    uint256 public tokenID;
    bool internal buyerCancel = false;
    bool internal sellerCancel = false;
    ProjectState public projectState;

    event StateUpdated(ProjectState state);

    constructor(address sender, address buyer) payable {
        sellerAddress = payable(sender);
        if(buyer != address(0)) {
            buyerAddress = payable(buyer);
        }
        projectState = ProjectState.newEscrow;
    }

    function onERC721Received(address operator, address from, uint256 tokenId, bytes calldata data ) public override returns (bytes4) {
        return this.onERC721Received.selector;
    }
    
    function depositNFT(address _NFTAddress, uint256 _TokenID)
        public
        inProjectState(ProjectState.newEscrow)
        onlySeller
    {
        nftAddress = _NFTAddress;
        tokenID = _TokenID;
        ERC721(nftAddress).safeTransferFrom(msg.sender, address(this), tokenID);
        projectState = ProjectState.nftDeposited;
        emit StateUpdated(projectState);
    }
    
    function cancelAtNFT()
        public
        inProjectState(ProjectState.nftDeposited)
        onlySeller
    {
        ERC721(nftAddress).safeTransferFrom(address(this), msg.sender, tokenID);
        projectState = ProjectState.cancelNFT;
        emit StateUpdated(projectState);
    }
  
    function cancelBeforeDelivery(bool _state)
        public
        inProjectState(ProjectState.ethDeposited)
        payable
        BuyerOrSeller
    {
        if (msg.sender == sellerAddress){
            sellerCancel = _state;
        }
        else{
            buyerCancel = _state;
        }
        
        if (sellerCancel == true && buyerCancel == true){
            ERC721(nftAddress).safeTransferFrom(address(this), sellerAddress, tokenID);
            buyerAddress.transfer(address(this).balance);
            projectState = ProjectState.canceledBeforeDelivery;    
            emit StateUpdated(projectState);
        }
    }
    
    function depositETH()
        public
        payable
        inProjectState(ProjectState.nftDeposited)
    {
        if(buyerAddress == address(0)) {
            buyerAddress = payable(msg.sender);
        }
        projectState = ProjectState.ethDeposited;
        emit StateUpdated(projectState);
    }
    
    function initiateDelivery()
        public
        inProjectState(ProjectState.ethDeposited)
        onlySeller
        noDispute
    {
        projectState = ProjectState.deliveryInitiated;
        emit StateUpdated(projectState);
    }        
    
    function confirmDelivery()
        public
        payable
        inProjectState(ProjectState.deliveryInitiated)
        onlyBuyer
    {
        ERC721(nftAddress).safeTransferFrom(address(this), buyerAddress, tokenID);
        sellerAddress.transfer(address(this).balance);
        projectState = ProjectState.delivered;
        emit StateUpdated(projectState);
    }
        
   	modifier condition(bool _condition) {
		require(_condition);
		_;
	}

	modifier onlySeller() {
		require(msg.sender == sellerAddress);
		_;
	}

	modifier onlyBuyer() {
		require(msg.sender == buyerAddress);
		_;
	}
	
	modifier noDispute(){
	    require(buyerCancel == false && sellerCancel == false);
	    _;
	}
	
	modifier BuyerOrSeller() {
		require(msg.sender == buyerAddress || msg.sender == sellerAddress);
		_;
	}
	
	modifier inProjectState(ProjectState _state) {
		require(projectState == _state);
		_;
	}

    function getBalance()
        public
        view
        returns (uint256 balance)
    {
        return address(this).balance;
    }
} 