using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace WatchNFT.Server.Controllers
{
    public partial class ContractInteractionController
    {
        [HttpPost("CreateListing")]
        public async Task<string> CreateListing(CreateListingModel model)
            => await _nftService.ListingController.CreateListing(model.Price, model.TokenId, model.PayTo);
        [HttpGet("Listings")]
        public async Task<List<FixedListing>> GetAllListings()
            => await _nftService.ListingController.GetAllListings();
        [HttpGet("Listings/{sellerAddress}")]
        public async Task<List<FixedListing>> GetAllListings(string sellerAddress)
            => await _nftService.ListingController.GetAllListings(sellerAddress);
        [HttpGet("Listing")]
        public async Task<FixedListing> GetListing(string address)
            => await _nftService.ListingController.GetListing(address);
        [HttpGet("ListingState")]
        public async Task<AuctionState> GetListingState(string address)
            => await _nftService.ListingController.GetListingState(address);
    }
}