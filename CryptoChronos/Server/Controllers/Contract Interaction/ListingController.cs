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
        {
            var address = await _nftService.ListingController.CreateListing(model.Price, model.TokenId, model.PayTo);
            var record = new LocalListingRecord()
            {
                ImageCID = model.Watch.ImageCID,
                ListingAddress = address,
                IsActive = true,
                ListingType = ListingType.FIXED,
                SellerAddress = model.SellerAddress,
                TokenId = model.TokenId,
            };
            _context.Add(record);
            _context.SaveChanges();
            return address;
        }

        [HttpGet("Listings")]
        public List<LocalListingRecord> GetAllListings()
            => _context.LocalListingRecords.Where(x => x.ListingType == ListingType.FIXED).Where(x => x.IsActive == true).ToList();
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