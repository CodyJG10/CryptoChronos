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
using Watches.Contracts.NftEscrow.ContractDefinition;

namespace Watches.Contracts.NftEscrow
{
    public partial class NftEscrowService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, NftEscrowDeployment nftEscrowDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<NftEscrowDeployment>().SendRequestAndWaitForReceiptAsync(nftEscrowDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, NftEscrowDeployment nftEscrowDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<NftEscrowDeployment>().SendRequestAsync(nftEscrowDeployment);
        }

        public static async Task<NftEscrowService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, NftEscrowDeployment nftEscrowDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, nftEscrowDeployment, cancellationTokenSource);
            return new NftEscrowService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public NftEscrowService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> BuyerAddressQueryAsync(BuyerAddressFunction buyerAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyerAddressFunction, string>(buyerAddressFunction, blockParameter);
        }

        
        public Task<string> BuyerAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BuyerAddressFunction, string>(null, blockParameter);
        }

        public Task<string> CancelAtNFTRequestAsync(CancelAtNFTFunction cancelAtNFTFunction)
        {
             return ContractHandler.SendRequestAsync(cancelAtNFTFunction);
        }

        public Task<string> CancelAtNFTRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CancelAtNFTFunction>();
        }

        public Task<TransactionReceipt> CancelAtNFTRequestAndWaitForReceiptAsync(CancelAtNFTFunction cancelAtNFTFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelAtNFTFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CancelAtNFTRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CancelAtNFTFunction>(null, cancellationToken);
        }

        public Task<string> CancelBeforeDeliveryRequestAsync(CancelBeforeDeliveryFunction cancelBeforeDeliveryFunction)
        {
             return ContractHandler.SendRequestAsync(cancelBeforeDeliveryFunction);
        }

        public Task<TransactionReceipt> CancelBeforeDeliveryRequestAndWaitForReceiptAsync(CancelBeforeDeliveryFunction cancelBeforeDeliveryFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelBeforeDeliveryFunction, cancellationToken);
        }

        public Task<string> CancelBeforeDeliveryRequestAsync(bool state)
        {
            var cancelBeforeDeliveryFunction = new CancelBeforeDeliveryFunction();
                cancelBeforeDeliveryFunction.State = state;
            
             return ContractHandler.SendRequestAsync(cancelBeforeDeliveryFunction);
        }

        public Task<TransactionReceipt> CancelBeforeDeliveryRequestAndWaitForReceiptAsync(bool state, CancellationTokenSource cancellationToken = null)
        {
            var cancelBeforeDeliveryFunction = new CancelBeforeDeliveryFunction();
                cancelBeforeDeliveryFunction.State = state;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelBeforeDeliveryFunction, cancellationToken);
        }

        public Task<string> ConfirmDeliveryRequestAsync(ConfirmDeliveryFunction confirmDeliveryFunction)
        {
             return ContractHandler.SendRequestAsync(confirmDeliveryFunction);
        }

        public Task<string> ConfirmDeliveryRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ConfirmDeliveryFunction>();
        }

        public Task<TransactionReceipt> ConfirmDeliveryRequestAndWaitForReceiptAsync(ConfirmDeliveryFunction confirmDeliveryFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmDeliveryFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ConfirmDeliveryRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ConfirmDeliveryFunction>(null, cancellationToken);
        }

        public Task<string> DepositETHRequestAsync(DepositETHFunction depositETHFunction)
        {
             return ContractHandler.SendRequestAsync(depositETHFunction);
        }

        public Task<string> DepositETHRequestAsync()
        {
             return ContractHandler.SendRequestAsync<DepositETHFunction>();
        }

        public Task<TransactionReceipt> DepositETHRequestAndWaitForReceiptAsync(DepositETHFunction depositETHFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depositETHFunction, cancellationToken);
        }

        public Task<TransactionReceipt> DepositETHRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<DepositETHFunction>(null, cancellationToken);
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

        public Task<BigInteger> GetBalanceQueryAsync(GetBalanceFunction getBalanceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceFunction, BigInteger>(getBalanceFunction, blockParameter);
        }

        
        public Task<BigInteger> GetBalanceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetBalanceFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> InitiateDeliveryRequestAsync(InitiateDeliveryFunction initiateDeliveryFunction)
        {
             return ContractHandler.SendRequestAsync(initiateDeliveryFunction);
        }

        public Task<string> InitiateDeliveryRequestAsync()
        {
             return ContractHandler.SendRequestAsync<InitiateDeliveryFunction>();
        }

        public Task<TransactionReceipt> InitiateDeliveryRequestAndWaitForReceiptAsync(InitiateDeliveryFunction initiateDeliveryFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initiateDeliveryFunction, cancellationToken);
        }

        public Task<TransactionReceipt> InitiateDeliveryRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<InitiateDeliveryFunction>(null, cancellationToken);
        }

        public Task<string> NftAddressQueryAsync(NftAddressFunction nftAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NftAddressFunction, string>(nftAddressFunction, blockParameter);
        }

        
        public Task<string> NftAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NftAddressFunction, string>(null, blockParameter);
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

        public Task<byte> ProjectStateQueryAsync(ProjectStateFunction projectStateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProjectStateFunction, byte>(projectStateFunction, blockParameter);
        }

        
        public Task<byte> ProjectStateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ProjectStateFunction, byte>(null, blockParameter);
        }

        public Task<string> SellerAddressQueryAsync(SellerAddressFunction sellerAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerAddressFunction, string>(sellerAddressFunction, blockParameter);
        }

        
        public Task<string> SellerAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SellerAddressFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TokenIDQueryAsync(TokenIDFunction tokenIDFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIDFunction, BigInteger>(tokenIDFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenIDQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIDFunction, BigInteger>(null, blockParameter);
        }
    }
}
