using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;

namespace CryptoChronos.Shared.Services
{
    public interface IContractInteractionService
    {
        public Task<List<string>> GetAllNfts(string owner);
        public Task<string> StoreNftData(MintWatchModel model);
        public Task<List<LocalWatchRecord>> GetAllNfts();
        public Task<string> GetTokenUri(string tokenId);
        public Task<string> GetNftOwner(string tokenId);
        public Task<string> GetNftMetadata(string url);
        public Task<EscrowStatus> GetEscrowState(string address);
        public Task<List<string>> GetAllEscrowContracts();
        public Task<List<string>> GetEscrowContractsForSeller(string sellerAddress);
        public Task<List<string>> GetEscrowContractsForBuyer(string buyerAddress);
        public Task<EscrowContract> GetEscrow(string addres);
        public Task<string> GetEscrowAddressFromTransaction(string txHash, string owner);
    }
}