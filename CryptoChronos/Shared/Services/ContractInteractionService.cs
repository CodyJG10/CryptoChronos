using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using System.Net.Http.Json;

namespace CryptoChronos.Shared.Services
{
    public class ContractInteractionService : IContractInteractionService
    {
        private readonly HttpClient _httpClient;

        public ContractInteractionService(HttpClient client)
        {
            _httpClient = client;
        }

        #region Auction

        public async Task<string> CreateAuction(CreateAuctionModel model)
        {
            var response = await _httpClient.PostAsJsonAsync("CreateAuction", model);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        public async Task<List<Auction>> GetAllAuctions()
            => await _httpClient.GetFromJsonAsync<List<Auction>>("Auctions");

        public async Task<List<Auction>> GetAllAuctions(string sellerAddress)
            => await _httpClient.GetFromJsonAsync<List<Auction>>("Auctions/" + sellerAddress);

        public async Task<Auction> GetAuction(string auctionAddress)
            => await _httpClient.GetFromJsonAsync<Auction>("auction?address=" + auctionAddress);

        public async Task<AuctionState> GetAuctionState(string auctionAddress)
            => await _httpClient.GetFromJsonAsync<AuctionState>("AuctionState?address=" + auctionAddress);

        public async Task<string> GetBidForUser(string auctionAddress, string userAddress)
            => await _httpClient.GetStringAsync("Bid?address=" + auctionAddress + "&userAddress=" + userAddress);

        public async Task<string> GetHighestBid(string auctionAddress)
            => await _httpClient.GetStringAsync("HighestBid/" + auctionAddress);

        public async Task<string> GetHighestBidder(string auctionAddress)
            => await _httpClient.GetStringAsync("HighestBidder/" + auctionAddress);


        #endregion

        #region Listings

        public async Task<string> CreateListing(CreateListingModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("CreateListing", model);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<FixedListing> GetListing(string listingAddress)
            => await _httpClient.GetFromJsonAsync<FixedListing>("listing?address=" + listingAddress);


        public async Task<List<FixedListing>> GetAllListings()
            => await _httpClient.GetFromJsonAsync<List<FixedListing>>("Listings");

        public async Task<List<FixedListing>> GetAllListings(string sellerAddress)
            => await _httpClient.GetFromJsonAsync<List<FixedListing>>("Listings/" + sellerAddress);

        #endregion

        #region NFT

        public async Task<List<string>> GetAllNfts(string owner)
            => await _httpClient.GetFromJsonAsync<List<string>>("nfts/" + owner);

        public async Task<List<LocalWatchRecord>> GetAllNfts()
            => await _httpClient.GetFromJsonAsync<List<LocalWatchRecord>>("nfts");

        public async Task<AuctionState> GetListingState(string listingAddress)
            => await _httpClient.GetFromJsonAsync<AuctionState>("ListingState?address=" + listingAddress);
        public async Task<string> GetNftMetadata(string url)
            => await _httpClient.GetStringAsync("NftMetadata?url=" + url);

        public async Task<string> GetNftOwner(string tokenId)
            => await _httpClient.GetStringAsync("ownerOf?tokenId=" + tokenId);

        public async Task<string> GetTokenUri(string tokenId)
        {
            var result = await _httpClient.GetStringAsync("TokenUri?tokenId=" + tokenId);
            return result;
        }
        public async Task<string> MintNft(MintNftModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("MintNft", model);
            return await result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Escrow

        public async Task<List<string>> GetAllEscrowContracts()
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts");

        public async Task<List<string>> GetEscrowContractsForBuyer(string buyerAddress)
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts?buyerAddress=" + buyerAddress);

        public async Task<List<string>> GetEscrowContractsForSeller(string sellerAddress)
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts?sellerAddress=" + sellerAddress);

        public async Task<EscrowStatus> GetEscrowState(string address)
            => await _httpClient.GetFromJsonAsync<EscrowStatus>("EscrowState?address=" + address);

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            (await GetAllListings()).ForEach(x => products.Add(x));
            (await GetAllAuctions()).ForEach(x => products.Add(x));
            return products;
        }

        public async Task<EscrowContract> GetEscrow(string address)
            => await _httpClient.GetFromJsonAsync<EscrowContract>("EscrowContract?address=" + address);

        public async Task<string> GetEscrowAddressFromTransaction(string txHash, string owner)
            => await _httpClient.GetStringAsync("EscrowAddress?transaction=" + txHash + "&owner=" + owner);

        #endregion
    }
}
