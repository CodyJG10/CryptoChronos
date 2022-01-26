using CryptoChronos.Shared.DTOs;

namespace NFT.ContractInteraction.Server.Interfaces
{
    public interface INftController
    {
        //public Task<MintWatchReceipt> MintNft(MintWatchModel model);
        public Task<List<string>> GetAllNfts(string ownerAddress);
        public Task<List<string>> GetAllNftsFromWeb3();
        public Task<string> GetTokenUri(string tokenId);
        public Task<string> GetNftOwner(string tokenId);
    }
}