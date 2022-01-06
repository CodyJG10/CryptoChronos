//SPDX-License-Identifier: MIT

pragma solidity ^0.8.10;

import "./Auction.sol";

contract AuctionFactory {

    address[] public auctions;
    uint256 public totalAuctions;

    event AuctionCreated(address auctionContract, address owner);

    // The site owner always runs this function. 
    // The auction is created on behalf of a specific address
    function createAuction(uint bidIncrement, address payTo, address operator) public {
        Auction newAuction = new Auction(bidIncrement, payTo, operator);
        auctions.push(address(newAuction));
        totalAuctions++;
        emit AuctionCreated(address(newAuction), operator);
    }
}