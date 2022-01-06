using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace WatchNFT.Server.Controllers
{
    public partial class ContractInteractionController
    {
        [HttpPost("CreateAuction")]
        public async Task<string> CreateAuction(CreateAuctionModel model)
        {
            var result = await _nftService.AuctionController.CreateAuction(model.BidIncrement, model.TokenId, model.PayTo, model.OperatorAddress);
            return result;
        }
        [HttpGet("Auctions")]
        public async Task<List<Auction>> GetAllAuctions()
            => await _nftService.AuctionController.GetAllAuctions();
        [HttpGet("Auctions/{owner}")]
        public async Task<List<Auction>> GetAllAuctions(string owner)
           => await _nftService.AuctionController.GetAllAuctions(owner);
        [HttpGet("Auction")]
        public async Task<Auction> GetAuction(string address)
           => await _nftService.AuctionController.GetAuction(address);
        [HttpGet("AuctionState")]
        public async Task<AuctionState> GetAuctionState(string address)
           => await _nftService.AuctionController.GetAuctionState(address);
        [HttpGet("Bid")]
        public async Task<string> GetBidForUser(string address, string userAddress)
            => await _nftService.AuctionController.GetCurrentBidForUser(address, userAddress);
        [HttpGet("HighestBid/{address}")]
        public async Task<string> GetHighestBid(string address)
        {
            var result = await _nftService.AuctionController.GetHighestBid(address);
            return result;
        }
        [HttpGet("HighestBidder/{address}")]
        public async Task<string> GetHighestBidder(string address)
        {
            var result = await _nftService.AuctionController.GetHighestBidder(address);
            return result;
        }
    }
}
