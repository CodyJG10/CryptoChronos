using CryptoChronos.Shared.DTOs;
using Nethereum.RPC.Eth.DTOs;

namespace NFT.ContractInteraction.Client.Interfaces
{
    public interface INftController
    {
        public Task<string> TransferNft(string toAddress, string tokenId, string contractAddress);
        public Task<string> ApproveForTranser(string approveAddress, string tokenId);
        public Task<TransactionReceipt> MintNft(MintWatchModel model, string ipfsHash);
    }
}