﻿using CryptoChronos.Shared.Models;
using Pinata.Client;

namespace NFT.ContractInteraction.Server
{
    public class StorageHelper
    {
        private string apiKey;
        private string apiSecret;

        private PinataClient _client;

        public StorageHelper(string apiKey, string apiSecret)
        {
            this.apiKey = apiKey;
            this.apiSecret = apiSecret;
            Connect();
        }

        private void Connect()
        {
            var config = new Config
            {
                ApiKey = apiKey,
                ApiSecret = apiSecret
            };
            _client = new PinataClient(config);
        }

        public async Task<string[]> StoreNewNFT(byte[] fileData, Watch watch, string tokenId)
        {
            var imageId = await PinImage(fileData);
            watch.ImageCID = imageId;
            var meta = new PinataMetadata
            {
                Name = tokenId,
            };
            var result = await _client.Pinning.PinJsonToIpfsAsync(watch, meta);
            return new string[] { result.IpfsHash, imageId };
        }

        private async Task<string> PinImage(byte[] fileData)
        {
            var result = await _client.Pinning.PinFileToIpfsAsync((content) => content.AddPinataFile(new StreamContent(new MemoryStream(fileData)), Guid.NewGuid().ToString()));
            return result.IpfsHash;
        }

        public static string GetImageUri(string id) => "https://ipfs.io/ipfs/" + id;

        public async Task<string> GetJsonFromIpfs(string url)
        {
            try
            {
                HttpClient http = new HttpClient();
                var result = await http.GetAsync(url);
                return await result.Content.ReadAsStringAsync();
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}