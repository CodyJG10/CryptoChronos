
using NFT.ContractInteraction.Server.Interfaces;
using System.Numerics;
using Watches.Contracts.WatchNFT;
using Watches.Contracts.WatchNFT.ContractDefinition;

namespace NFT.ContractInteraction.Server.Implementations
{
    public class NftController : INftController
    {
        private NethereumClient _client;
        private StorageHelper _storage;

        public NftController(NethereumClient client, StorageHelper storage)
        {
            _client = client;
            _storage = storage;
        }

        public async Task<List<string>> GetAllNfts(string ownerAddress)
        {
            List<string> ids = new List<string>();
            WatchNFTService nftService = new WatchNFTService(_client.Web3, _client.NftAddress);
            var balance = await nftService.BalanceOfQueryAsync(ownerAddress);
            for (int i = 0; i < balance; i++)
            {
                var nft = await nftService.TokenOfOwnerByIndexQueryAsync(ownerAddress, i);
                ids.Add(nft.ToString());
            }
            return ids;
        }

        public async Task<List<string>> GetAllNftsFromWeb3()
        {
            List<string> ids = new List<string>();
            WatchNFTService nftService = new WatchNFTService(_client.Web3, _client.NftAddress);
            var supply = await nftService.TotalSupplyQueryAsync();
            for (int i = 0; i < supply; i++)
            {
                var nft = await nftService.TokenByIndexQueryAsync(i);
                ids.Add(nft.ToString());
            }
            return ids;
        }

        public async Task<string> GetTokenUri(string tokenId)
        {
            WatchNFTService nftService = new WatchNFTService(_client.Web3, _client.NftAddress);
            var uri = await nftService.TokenURIQueryAsync(BigInteger.Parse(tokenId));
            return uri;
        }

        public async Task<string> GetNftOwner(string tokenId)
        {
            WatchNFTService service = new WatchNFTService(_client.Web3, _client.NftAddress);
            OwnerOfFunction func = new OwnerOfFunction()
            {
                TokenId = BigInteger.Parse(tokenId)
            };
            return await service.OwnerOfQueryAsync(func);
        }
    }
}