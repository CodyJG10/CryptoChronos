using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Nethereum.Contracts;
using NFT.ContractInteraction.Server.Interfaces;
using System.Numerics;
using Watches.Contracts.ListingEscrow;
using Watches.Contracts.ListingEscrow.ContractDefinition;
using Watches.Contracts.ListingFactory;
using Watches.Contracts.ListingFactory.ContractDefinition;
using Watches.Contracts.WatchNFT;
using Watches.Contracts.WatchNFT.ContractDefinition;

namespace NFT.ContractInteraction.Server.Implementations
{
    public class ListingsController : IListingController
    {
        private readonly NethereumClient _client;

        public ListingsController(NethereumClient client)
        {
            _client = client;
        }

        public async Task<string> CreateListing(string price, string tokenId, string payTo)
        {
            ListingFactoryService listingFactoryService = new ListingFactoryService(_client.Web3, _client.ListingFactoryAddress);
            CreateListingFunction func = new CreateListingFunction()
            {
                Price = BigInteger.Parse(price),
                TokenId = BigInteger.Parse(tokenId),
                NftAddress = _client.NftAddress,
                PayTo = payTo
            };
            var receipt = await listingFactoryService.CreateListingRequestAndWaitForReceiptAsync(func);
            var eventOutput = receipt.DecodeAllEvents<ListingCreatedEventDTO>();
            //TODO Ensure this is correct address
            var ownerAddress = _client.Web3.TransactionManager.Account.Address;
            var listingAddress = eventOutput.Single(x => x.Event.Owner.ToLower() == ownerAddress.ToLower()).Event.ListingContract;

            WatchNFTService nftService = new WatchNFTService(_client.Web3, _client.NftAddress);
            var approveFunc = new ApproveFunction()
            {
                To = listingAddress,
                TokenId = BigInteger.Parse(tokenId)
            };
            await nftService.ApproveRequestAndWaitForReceiptAsync(approveFunc);

            var listingService = new ListingEscrowService(_client.Web3, listingAddress);
            DepositNFTFunction depositFunc = new DepositNFTFunction()
            {
                NFTAddress = _client.NftAddress,
                TokenID = BigInteger.Parse(tokenId)
            };
            await listingService.DepositNFTRequestAndWaitForReceiptAsync(depositFunc);

            return listingAddress;
        }

        public async Task<List<FixedListing>> GetAllListings()
        {

            ListingFactoryService service = new ListingFactoryService(_client.Web3, _client.ListingFactoryAddress);
            var numberOfListings = await service.TotalListingsQueryAsync();
            List<string> listings = new List<string>();
            for (int i = 0; i < numberOfListings; i++)
            {
                var listing = await service.ListingsQueryAsync(i);
                listings.Add(listing);
            }
            List<FixedListing> results = new List<FixedListing>();
            foreach (var listing in listings)
            {
                ListingEscrowService listingEscrowService = new ListingEscrowService(_client.Web3, listing);
                var tokenId = (await listingEscrowService.TokenIdQueryAsync()).ToString();
                var price = (await listingEscrowService.PriceQueryAsync()).ToString();
                var seller = await listingEscrowService.SellerQueryAsync();

                results.Add(new FixedListing()
                {
                    Price = price,
                    SellerAddress = seller,
                    TokenId = tokenId,
                    Address = listing
                });

            }
            return results;
        }

        public async Task<List<FixedListing>> GetAllListings(string sellerAddress)
        {
            var allListings = await GetAllListings();
            return allListings.Where(x => x.SellerAddress.ToLower() == sellerAddress.ToLower()).ToList();
        }

        public async Task<FixedListing> GetListing(string listingAddress)
        {
            var allListings = await GetAllListings();
            return allListings.Single(x => x.Address.ToLower() == listingAddress.ToLower());
        }

        public async Task<AuctionState> GetListingState(string listingAddress)
        {
            var service = new ListingEscrowService(_client.Web3, listingAddress);
            int state = int.Parse((await service.StateQueryAsync()).ToString());
            return (AuctionState)state;
        }
    }
}
