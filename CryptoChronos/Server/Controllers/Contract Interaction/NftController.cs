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
            try
            {
                var result = await _nftService.NftController.GetTokenUri(tokenId);
                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        [HttpPost("StoreNft")]
        // Returns IPFS CID
        public async Task<string> MintNft(MintWatchModel model)
        {
            var ipfsData = await _nftService.Storage.StoreNewNFT(model.FileData, model.Watch, model.TokenId);
            LocalWatchRecord watchRecord = new LocalWatchRecord()
            {
                Model = model.Watch.Model,
                Manufacturer = model.Watch.Manufacturer,
                NftId = model.TokenId,
                Serial = model.Watch.Serial,
                ImageCID = ipfsData[1],
                ChainId = int.Parse(_config["ChainId"])
            };
            _context.Add(watchRecord);
            _context.SaveChanges();
            return ipfsData[0];
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
