using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;

namespace NFT.ContractInteraction.Server.Interfaces
{
    public interface IListingController
    {
        public Task<List<FixedListing>> GetAllListings();
        public Task<List<FixedListing>> GetAllListings(string sellerAddress);
        public Task<FixedListing> GetListing(string listingAddress);
        public Task<string> CreateListing(string price, string tokenId, string payTo);
        public Task<AuctionState> GetListingState(string listingAddress);
    }
}
