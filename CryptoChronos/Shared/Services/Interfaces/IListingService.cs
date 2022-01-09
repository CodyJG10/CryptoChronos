using CryptoChronos.Shared.Models;

namespace CryptoChronos.Shared.Services
{
    public interface IListingService
    {
        public Task<AuctionMetadata> GetAuctionMetadata(string auctionAddress);
        public Task CreateAuctionMetadata(AuctionMetadata model);
        public Task UpdateMetadataViews(string auctionAddress);
        public Task CloseFixedListing(FixedListing listing);
        public Task CloseAuction(Auction auction);
    }
}