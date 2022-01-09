using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace WatchNFT.Server.Controllers
{
    public partial class ContractInteractionController
    {
        [HttpGet("nfts/{address}")]
        public async Task<List<string>> GetAllNfts(string address)
        {
            var result = await _nftService.NftController.GetAllNfts(address);
            return result;
        }
        [HttpGet("nfts")]
        public List<LocalWatchRecord> GetAllNfts()
            => _context.LocalWatchRecords.ToList();
        [HttpGet("TokenUri")]
        public async Task<string> GetTokenUri(string tokenId)
        {
            var result = await _nftService.NftController.GetTokenUri(tokenId);
            return result;
        }
        [HttpPost("MintNft")]
        public async Task<string> MintNft(MintWatchModel model)
        {
            var receipt = await _nftService.NftController.MintNft(model);
            LocalWatchRecord watchRecord = new LocalWatchRecord()
            {
                Model = model.Watch.Model,
                Manufacturer = model.Watch.Manufacturer,
                NftId = receipt.TokenId,
                Serial = model.Watch.Serial,
                ImageCID = receipt.ImageCID
            };
            _context.Add(watchRecord);
            _context.SaveChanges();
            return receipt.TokenId;
        }
        [HttpGet("OwnerOf")]
        public async Task<string> GetNftOwner(string tokenId)
            => await _nftService.NftController.GetNftOwner(tokenId);
        [HttpGet("NftMetadata")]
        public async Task<string> GetJsonFromIpfs(string url)
        {
            var result = await _nftService.Storage.GetJsonFromIpfs(url);
            return result;
        }
    }
}
