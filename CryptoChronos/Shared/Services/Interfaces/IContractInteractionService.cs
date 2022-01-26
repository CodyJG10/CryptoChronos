using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;

namespace CryptoChronos.Shared.Services
{
    public interface IContractInteractionService
    {
        public Task<string> CreateAuction(CreateAuctionModel model);
        public Task<List<LocalListingRecord>> GetAllAuctions();
        public Task<List<Auction>> GetAllAuctions(string sellerAddress);
        public Task<Auction> GetAuction(string auctionAddress);
        public Task<AuctionState> GetAuctionState(string auctionAddress);
        public Task<string> GetBidForUser(string auctionAddress, string userAddress);
        public Task<string> GetHighestBid(string auctionAddress);
        public Task<string> GetHighestBidder(string auctionAddress);
        public Task<string> CreateListing(CreateListingModel model);
        public Task<List<LocalListingRecord>> GetAllListings();
        public Task<List<FixedListing>> GetAllListings(string sellerAddress);
        public Task<AuctionState> GetListingState(string listingAddress);
        public Task<FixedListing> GetListing(string listingAddress);
        public Task<List<string>> GetAllNfts(string owner);
        public Task<List<LocalWatchRecord>> GetAllNfts();
        public Task<string> GetTokenUri(string tokenId);
        public Task<string> MintNft(MintWatchModel model);
        public Task<string> GetNftOwner(string tokenId);
        public Task<string> GetNftMetadata(string url);
        public Task<EscrowStatus> GetEscrowState(string address);
        public Task<List<string>> GetAllEscrowContracts();
        public Task<List<string>> GetEscrowContractsForSeller(string sellerAddress);
        public Task<List<string>> GetEscrowContractsForBuyer(string buyerAddress);
        public Task<List<LocalListingRecord>> GetAllProducts();
        public Task<EscrowContract> GetEscrow(string addres);
        public Task<string> GetEscrowAddressFromTransaction(string txHash, string owner);
    }
}