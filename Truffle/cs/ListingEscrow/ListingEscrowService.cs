using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Watches.Contracts.ListingEscrow.ContractDefinition;

namespace Watches.Contracts.ListingEscrow
{
    public partial class ListingEscrowService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ListingEscrowDeployment listingEscrowDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ListingEscrowDeployment>().SendRequestAndWaitForReceiptAsync(listingEscrowDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ListingEscrowDeployment listingEscrowDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ListingEscrowDeployment>().SendRequestAsync(listingEscrowDeployment);
        }

        public static async Task<ListingEscrowService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ListingEscrowDeployment listingEscrowDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, listingEscrowDeployment, cancellationTokenSource);
            return new ListingEscrowService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ListingEscrowService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CancelRequestAsync(CancelFunction cancelFunction)
        {
             return ContractHandler.SendRequestAsync(cancelFunction);
        }

        public Task<string> CancelRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CancelFunction>();
        }

        public Task<TransactionReceipt> CancelRequestAndWaitForReceiptAsync(CancelFunction cancelFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CancelRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CancelFunction>(null, cancellationToken);
        }

        public Task<string> DepositNFTRequestAsync(DepositNFTFunction depositNFTFunction)
        {
             return ContractHandler.SendRequestAsync(depositNFTFunction);
        }

        public Task<TransactionReceipt> DepositNFTRequestAndWaitForReceiptAsync(DepositNFTFunction depositNFTFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositNFTFunction, cancellationToken);
        }

        public Task<string> DepositNFTRequestAsync(string nFTAddress, BigInteger tokenID)
        {
            var depositNFTFunction = new DepositNFTFunction();
                depositNFTFunction.NFTAddress = nFTAddress;
                depositNFTFunction.TokenID = tokenID;
            
             return ContractHandler.SendRequestAsync(depositNFTFunction);
        }

        public Task<TransactionReceipt> DepositNFTRequestAndWaitForReceiptAsync(string nFTAddress, BigInteger tokenID, CancellationTokenSource cancellationToken = null)
        {
            var depositNFTFunction = new DepositNFTFunction();
                depositNFTFunction.NFTAddress = nFTAddress;
                depositNFTFunction.TokenID = tokenID;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositNFTFunction, cancellationToken);
        }

        public Task<string> OnERC721ReceivedRequestAsync(OnERC721ReceivedFunction onERC721ReceivedFunction)
        {
             return ContractHandler.SendRequestAsync(onERC721ReceivedFunction);
        }

        public Task<TransactionReceipt> OnERC721ReceivedRequestAndWaitForReceiptAsync(OnERC721ReceivedFunction onERC721ReceivedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC721ReceivedFunction, cancellationToken);
        }

        public Task<string> OnERC721ReceivedRequestAsync(string @operator, string from, BigInteger tokenId, byte[] data)
        {
            var onERC721ReceivedFunction = new OnERC721ReceivedFunction();
                onERC721ReceivedFunction.Operator = @operator;
                onERC721ReceivedFunction.From = from;
                onERC721ReceivedFunction.TokenId = tokenId;
                onERC721ReceivedFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(onERC721ReceivedFunction);
        }

        public Task<TransactionReceipt> OnERC721ReceivedRequestAndWaitForReceiptAsync(string @operator, string from, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var onERC721ReceivedFunction = new OnERC721ReceivedFunction();
                onERC721ReceivedFunction.Operator = @operator;
                onERC721ReceivedFunction.From = from;
                onERC721ReceivedFunction.TokenId = tokenId;
                onERC721ReceivedFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC721ReceivedFunction, cancellationToken);
        }

        public Task<BigInteger> PriceQueryAsync(PriceFunction priceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(priceFunction, blockParameter);
        }

        
        public Task<BigInteger> PriceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PriceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> PurchaseRequestAsync(PurchaseFunction purchaseFunction)
        {
             return ContractHandler.SendRequestAsync(purchaseFunction);
        }

        public Task<string> PurchaseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<PurchaseFunction>();
        }

        public Task<TransactionReceipt> PurchaseRequestAndWaitForReceiptAsync(PurchaseFunction purchaseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(purchaseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PurchaseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<PurchaseFunction>(null, cancellationToken);
        }

        public Task<string> SellerQueryAsync(SellerFunction sellerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerFunction, string>(sellerFunction, blockParameter);
        }

        
        public Task<string> SellerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerFunction, string>(null, blockParameter);
        }

        public Task<byte> StateQueryAsync(StateFunction stateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StateFunction, byte>(stateFunction, blockParameter);
        }

        
        public Task<byte> StateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StateFunction, byte>(null, blockParameter);
        }

        public Task<BigInteger> TokenIdQueryAsync(TokenIdFunction tokenIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIdFunction, BigInteger>(tokenIdFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenIdQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIdFunction, BigInteger>(null, blockParameter);
        }
    }
}
