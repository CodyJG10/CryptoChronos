using CryptoChronos.Shared.DTOs;
using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using System.Net.Http.Json;

namespace CryptoChronos.Shared.Services
{
    public class ContractInteractionService : IContractInteractionService
    {
        private readonly HttpClient _httpClient;

        public ContractInteractionService(HttpClient client)
        {
            _httpClient = client;
        }

        #region NFT

        public async Task<List<string>> GetAllNfts(string owner)
            => await _httpClient.GetFromJsonAsync<List<string>>("nfts/" + owner);

        public async Task<List<LocalWatchRecord>> GetAllNfts()
            => await _httpClient.GetFromJsonAsync<List<LocalWatchRecord>>("nfts");

        public async Task<string> GetNftMetadata(string url)
            => await _httpClient.GetStringAsync("NftMetadata?url=" + url);

        public async Task<string> GetNftOwner(string tokenId)
            => await _httpClient.GetStringAsync("ownerOf?tokenId=" + tokenId);

        public async Task<string> GetTokenUri(string tokenId)
        {
            var result = await _httpClient.GetStringAsync("TokenUri?tokenId=" + tokenId);
            return result;
        }

        // Returns URI
        public async Task<string> StoreNftData(MintWatchModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("StoreNFT", model);
            return await result.Content.ReadAsStringAsync();
        }

        #endregion

        #region Escrow

        public async Task<List<string>> GetAllEscrowContracts()
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts");

        public async Task<List<string>> GetEscrowContractsForBuyer(string buyerAddress)
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts?buyerAddress=" + buyerAddress);

        public async Task<List<string>> GetEscrowContractsForSeller(string sellerAddress)
            => await _httpClient.GetFromJsonAsync<List<string>>("EscrowContracts?sellerAddress=" + sellerAddress);

        public async Task<EscrowStatus> GetEscrowState(string address)
            => await _httpClient.GetFromJsonAsync<EscrowStatus>("EscrowState?address=" + address);

        public async Task<EscrowContract> GetEscrow(string address)
            => await _httpClient.GetFromJsonAsync<EscrowContract>("EscrowContract?address=" + address);

        public async Task<string> GetEscrowAddressFromTransaction(string txHash, string owner)
            => await _httpClient.GetStringAsync("EscrowAddress?transaction=" + txHash + "&owner=" + owner);
        #endregion
    }
}
