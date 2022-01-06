using CryptoChronos.Shared.Models;

namespace CryptoChronos.Shared.Services
{
    public interface IAuctionService
    {
        public Task<AuctionMetadata> GetAuctionMetadata(string auctionAddress);
        public Task CreateAuctionMetadata(AuctionMetadata model);
        public Task UpdateMetadataViews(string auctionAddress);
    }
}