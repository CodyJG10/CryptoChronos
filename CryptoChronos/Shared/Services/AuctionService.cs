using CryptoChronos.Shared.Models;
using System.Net.Http.Json;

namespace CryptoChronos.Shared.Services
{
    public class AuctionService : IAuctionService
    {
        private HttpClient _httpClient;

        public AuctionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateAuctionMetadata(AuctionMetadata model)
            => await _httpClient.PostAsJsonAsync("metadata", model);

        public async Task<AuctionMetadata> GetAuctionMetadata(string auctionAddress)
            => await _httpClient.GetFromJsonAsync<AuctionMetadata>("Metadata/" + auctionAddress);

        public async Task UpdateMetadataViews(string auctionAddress)
            => await _httpClient.PutAsync("Metadata/" + auctionAddress, null);
    }
}