using CryptoChronos.Shared.DTOs;
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
        public async Task<List<string>> GetAllNfts()
            => await _nftService.NftController.GetAllNfts();
        [HttpGet("TokenUri")]
        public async Task<string> GetTokenUri(string tokenId)
        {
            var result = await _nftService.NftController.GetTokenUri(tokenId);
            return result;
        }
        [HttpPost("MintNft")]
        public async Task<string> MintNft(MintNftModel model)
            => await _nftService.NftController.MintNft(model);
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
