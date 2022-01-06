using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Nethereum.Contracts;
using NFT.ContractInteraction.Server.Interfaces;
using System.Numerics;
using Watches.Contracts.Auction;
using Watches.Contracts.Auction.ContractDefinition;
using Watches.Contracts.AuctionFactory;
using Watches.Contracts.AuctionFactory.ContractDefinition;
using Watches.Contracts.WatchNFT;
using Watches.Contracts.WatchNFT.ContractDefinition;

namespace NFT.ContractInteraction.Server.Implementations
{
    public class AuctionController : IAuctionController
    {
        private NethereumClient _client;

        public AuctionController(NethereumClient client)
        {
            _client = client;
        }

        // Create auction delegated
        public async Task<string> CreateAuction(string bidIncrement, string tokenId, string payTo, string operatorAddress)
        {
            AuctionFactoryService service = new AuctionFactoryService(_client.Web3, _client.AuctionFactoryAddress);
            CreateAuctionFunction createFunc = new CreateAuctionFunction()
            {
                BidIncrement = BigInteger.Parse(bidIncrement),
                PayTo = payTo,
                Operator = operatorAddress
            };

            var receipt = await service.CreateAuctionRequestAndWaitForReceiptAsync(createFunc);
            var eventOutput = receipt.DecodeAllEvents<AuctionCreatedEventDTO>();
            //TODO Ensure this is correct address
            var ownerAddress = _client.Web3.TransactionManager.Account.Address;
            var auctionAddress = eventOutput.Single(x => x.Event.Owner.ToLower() == ownerAddress.ToLower()).Event.AuctionContract;

            WatchNFTService nftService = new WatchNFTService(_client.Web3, _client.NftAddress);
            var approveFunc = new ApproveFunction()
            {
                To = auctionAddress,
                TokenId = BigInteger.Parse(tokenId)
            };
            await nftService.ApproveRequestAndWaitForReceiptAsync(approveFunc);

            var auctionService = new AuctionService(_client.Web3, auctionAddress);
            DepositNFTFunction depositFunc = new DepositNFTFunction()
            {
                NFTAddress = _client.NftAddress,
                TokenID = BigInteger.Parse(tokenId)
            };
            await auctionService.DepositNFTRequestAndWaitForReceiptAsync(depositFunc);

            return auctionAddress;
        }

        public async Task<List<Auction>> GetAllAuctions()
        {
            AuctionFactoryService service = new AuctionFactoryService(_client.Web3, _client.AuctionFactoryAddress);
            var numberOfAuctions = await service.TotalAuctionsQueryAsync();
            List<string> auctions = new List<string>();
            for (int i = 0; i < numberOfAuctions; i++)
            {
                var auction = await service.AuctionsQueryAsync(i);
                auctions.Add(auction);
            }
            List<Auction> results = new List<Auction>();
            foreach (var auction in auctions)
            {
                AuctionService auctionService = new AuctionService(_client.Web3, auction);
                var tokenId = (await auctionService.TokenIdQueryAsync()).ToString();
                var seller = await auctionService.SellerQueryAsync();
                var bidIncrease = await auctionService.BidIncrementQueryAsync();
                var operatorAddress = await auctionService.OperatorQueryAsync();

                results.Add(new Auction()
                {
                    Address = auction,
                    SellerAddress = seller,
                    TokenId = tokenId,
                    BidIncrease = bidIncrease.ToString(),
                    OperatorAddress = operatorAddress
                });

            }
            return results;
        }

        public async Task<List<Auction>> GetAllAuctions(string sellerAddress)
        {
            var allAuctions = await GetAllAuctions();
            return allAuctions.Where(x => x.SellerAddress.ToLower() == sellerAddress.ToLower()).ToList();
        }

        public async Task<Auction> GetAuction(string address)
        {
            var allAuctions = await GetAllAuctions();
            return allAuctions.Single(x => x.Address.ToLower() == address.ToLower());
        }

        public async Task<AuctionState> GetAuctionState(string auctionAddress)
        {
            AuctionService service = new AuctionService(_client.Web3, auctionAddress);
            int state = int.Parse((await service.StateQueryAsync()).ToString());
            return (AuctionState)state;
        }

        public async Task<string> GetCurrentBidForUser(string auctionAddress, string userAddress)
        {
            AuctionService service = new AuctionService(_client.Web3, auctionAddress);
            var result = await service.FundsByBidderQueryAsync(userAddress);
            return result.ToString();
        }

        public async Task<string> GetHighestBid(string auctionAddress)
        {
            AuctionService service = new AuctionService(_client.Web3, auctionAddress);
            var result = await service.GetHighestBidQueryAsync();
            return result.ToString();
        }

        public async Task<string> GetHighestBidder(string auctionAddress)
        {
            AuctionService service = new AuctionService(_client.Web3, auctionAddress);
            var result = await service.HighestBidderQueryAsync();
            return result;
        }
    }
}
