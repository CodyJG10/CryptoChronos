using CryptoChronos.Shared.DTOs;

namespace NFT.ContractInteraction.Server.Interfaces
{
    public interface INftController
    {
        public Task<string> MintNft(MintNftModel model);
        public Task<List<string>> GetAllNfts(string ownerAddress);
        public Task<List<string>> GetAllNfts();
        public Task<string> GetTokenUri(string tokenId);
        public Task<string> GetNftOwner(string tokenId);
    }
}