using Microsoft.Extensions.DependencyInjection;
using NFT.ContractInteraction.Client.Implementations;
using NFT.ContractInteraction.Client.Interfaces;
using NFT.ContractInteraction.Client.Transactions;

namespace NFT.ContractInteraction.Client.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContractControllers(this IServiceCollection services)
        {
            services.AddTransient<INftController, NftController>();
            services.AddTransient<IListingController, ListingsController>();
            services.AddTransient<IAuctionController, AuctionController>();
            services.AddTransient<IEscrowController, EscrowController>();
            services.AddTransient<TransactionHandler, MetaMaskTransactionHandler>();
            services.AddTransient<NftClientService>();
        }
    }
}