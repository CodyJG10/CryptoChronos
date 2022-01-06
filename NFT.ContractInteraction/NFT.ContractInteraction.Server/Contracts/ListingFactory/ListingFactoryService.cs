using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Watches.Contracts.ListingFactory.ContractDefinition;

namespace Watches.Contracts.ListingFactory
{
    public partial class ListingFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ListingFactoryDeployment listingFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ListingFactoryDeployment>().SendRequestAndWaitForReceiptAsync(listingFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ListingFactoryDeployment listingFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ListingFactoryDeployment>().SendRequestAsync(listingFactoryDeployment);
        }

        public static async Task<ListingFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ListingFactoryDeployment listingFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, listingFactoryDeployment, cancellationTokenSource);
            return new ListingFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public ListingFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreateListingRequestAsync(CreateListingFunction createListingFunction)
        {
            return ContractHandler.SendRequestAsync(createListingFunction);
        }

        public Task<TransactionReceipt> CreateListingRequestAndWaitForReceiptAsync(CreateListingFunction createListingFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createListingFunction, cancellationToken);
        }

        public Task<string> CreateListingRequestAsync(BigInteger price, BigInteger tokenId, string nftAddress, string payTo)
        {
            var createListingFunction = new CreateListingFunction();
            createListingFunction.Price = price;
            createListingFunction.TokenId = tokenId;
            createListingFunction.NftAddress = nftAddress;
            createListingFunction.PayTo = payTo;

            return ContractHandler.SendRequestAsync(createListingFunction);
        }

        public Task<TransactionReceipt> CreateListingRequestAndWaitForReceiptAsync(BigInteger price, BigInteger tokenId, string nftAddress, string payTo, CancellationTokenSource cancellationToken = null)
        {
            var createListingFunction = new CreateListingFunction();
            createListingFunction.Price = price;
            createListingFunction.TokenId = tokenId;
            createListingFunction.NftAddress = nftAddress;
            createListingFunction.PayTo = payTo;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createListingFunction, cancellationToken);
        }

        public Task<string> ListingsQueryAsync(ListingsFunction listingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ListingsFunction, string>(listingsFunction, blockParameter);
        }


        public Task<string> ListingsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var listingsFunction = new ListingsFunction();
            listingsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ListingsFunction, string>(listingsFunction, blockParameter);
        }

        public Task<BigInteger> TotalListingsQueryAsync(TotalListingsFunction totalListingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalListingsFunction, BigInteger>(totalListingsFunction, blockParameter);
        }


        public Task<BigInteger> TotalListingsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalListingsFunction, BigInteger>(null, blockParameter);
        }
    }
}
