using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;

namespace NFT.ContractInteraction.Server.Interfaces
{
    public interface IAuctionController
    {
        public Task<Auction> GetAuction(string address);
        public Task<List<Auction>> GetAllAuctions();
        public Task<List<Auction>> GetAllAuctions(string sellerAddress);
        public Task<string> CreateAuction(string bidIncrement, string tokenId, string payTo, string operatorAddress);
        public Task<string> GetHighestBidder(string auctionAddress);
        public Task<string> GetHighestBid(string auctionAddress);
        public Task<AuctionState> GetAuctionState(string auctionAddress);
        public Task<string> GetCurrentBidForUser(string auctionAddress, string userAddress);
    }
}
