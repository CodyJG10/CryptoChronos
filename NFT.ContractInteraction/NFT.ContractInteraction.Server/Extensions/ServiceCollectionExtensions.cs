using Microsoft.Extensions.DependencyInjection;
using NFT.ContractInteraction.Server.Implementations;
using NFT.ContractInteraction.Server.Interfaces;

namespace NFT.ContractInteraction.Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContractControllers(this IServiceCollection services,
            string ownerPrivateKey, string pinataApiKey, string pinataApiSecret,
            string listingFactoryAddress, string nftAddress, string auctionFactoryAddress,
            string url, string chainId, string escrowManagerAddress)
        {
            NethereumClient client = new NethereumClient(ownerPrivateKey, chainId, escrowManagerAddress, auctionFactoryAddress, nftAddress, url, listingFactoryAddress);
            services.AddTransient(x => client);
            services.AddTransient<INftController, NftController>();
            services.AddTransient<IListingController, ListingsController>();
            services.AddTransient<IAuctionController, AuctionController>();
            services.AddTransient<IEscrowController, EscrowController>();
            services.AddTransient(x => new StorageHelper(pinataApiKey, pinataApiSecret));
            services.AddTransient<NftServerService>();
        }
    }
}