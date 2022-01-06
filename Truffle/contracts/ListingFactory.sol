//SPDX-License-Identifier: MIT

pragma solidity ^0.8.10;

import "./Listing.sol";

contract ListingFactory {

    uint256 public totalListings;
    address[] public listings;

    event ListingCreated(address listingContract, address owner);

    function createListing(uint256 price, uint256 tokenId, address nftAddress, address payTo) public {
        ListingEscrow listing = new ListingEscrow(price, payTo, msg.sender, tokenId, nftAddress);
        address listingAddress = address(listing);
        listings.push(listingAddress);
        totalListings++;
        emit ListingCreated(listingAddress, msg.sender);
    }
}