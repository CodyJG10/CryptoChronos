using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Watches.Contracts.AuctionFactory.ContractDefinition;

namespace Watches.Contracts.AuctionFactory
{
    public partial class AuctionFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AuctionFactoryDeployment auctionFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionFactoryDeployment>().SendRequestAndWaitForReceiptAsync(auctionFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AuctionFactoryDeployment auctionFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionFactoryDeployment>().SendRequestAsync(auctionFactoryDeployment);
        }

        public static async Task<AuctionFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AuctionFactoryDeployment auctionFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, auctionFactoryDeployment, cancellationTokenSource);
            return new AuctionFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public AuctionFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AuctionsQueryAsync(AuctionsFunction auctionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AuctionsFunction, string>(auctionsFunction, blockParameter);
        }


        public Task<string> AuctionsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var auctionsFunction = new AuctionsFunction();
            auctionsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<AuctionsFunction, string>(auctionsFunction, blockParameter);
        }

        public Task<string> CreateAuctionRequestAsync(CreateAuctionFunction createAuctionFunction)
        {
            return ContractHandler.SendRequestAsync(createAuctionFunction);
        }

        public Task<TransactionReceipt> CreateAuctionRequestAndWaitForReceiptAsync(CreateAuctionFunction createAuctionFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createAuctionFunction, cancellationToken);
        }

        public Task<string> CreateAuctionRequestAsync(BigInteger bidIncrement, string payTo, string @operator)
        {
            var createAuctionFunction = new CreateAuctionFunction();
            createAuctionFunction.BidIncrement = bidIncrement;
            createAuctionFunction.PayTo = payTo;
            createAuctionFunction.Operator = @operator;

            return ContractHandler.SendRequestAsync(createAuctionFunction);
        }

        public Task<TransactionReceipt> CreateAuctionRequestAndWaitForReceiptAsync(BigInteger bidIncrement, string payTo, string @operator, CancellationTokenSource cancellationToken = null)
        {
            var createAuctionFunction = new CreateAuctionFunction();
            createAuctionFunction.BidIncrement = bidIncrement;
            createAuctionFunction.PayTo = payTo;
            createAuctionFunction.Operator = @operator;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createAuctionFunction, cancellationToken);
        }

        public Task<BigInteger> TotalAuctionsQueryAsync(TotalAuctionsFunction totalAuctionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalAuctionsFunction, BigInteger>(totalAuctionsFunction, blockParameter);
        }


        public Task<BigInteger> TotalAuctionsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalAuctionsFunction, BigInteger>(null, blockParameter);
        }
    }
}
