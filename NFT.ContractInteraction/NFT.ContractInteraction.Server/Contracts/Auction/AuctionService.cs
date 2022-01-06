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
using Watches.Contracts.Auction.ContractDefinition;

namespace Watches.Contracts.Auction
{
    public partial class AuctionService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionDeployment>().SendRequestAndWaitForReceiptAsync(auctionDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AuctionDeployment>().SendRequestAsync(auctionDeployment);
        }

        public static async Task<AuctionService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AuctionDeployment auctionDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, auctionDeployment, cancellationTokenSource);
            return new AuctionService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AuctionService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<BigInteger> BidIncrementQueryAsync(BidIncrementFunction bidIncrementFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BidIncrementFunction, BigInteger>(bidIncrementFunction, blockParameter);
        }

        
        public Task<BigInteger> BidIncrementQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BidIncrementFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> CancelAuctionRequestAsync(CancelAuctionFunction cancelAuctionFunction)
        {
             return ContractHandler.SendRequestAsync(cancelAuctionFunction);
        }

        public Task<string> CancelAuctionRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CancelAuctionFunction>();
        }

        public Task<TransactionReceipt> CancelAuctionRequestAndWaitForReceiptAsync(CancelAuctionFunction cancelAuctionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cancelAuctionFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CancelAuctionRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CancelAuctionFunction>(null, cancellationToken);
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

        public Task<BigInteger> FundsByBidderQueryAsync(FundsByBidderFunction fundsByBidderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FundsByBidderFunction, BigInteger>(fundsByBidderFunction, blockParameter);
        }

        
        public Task<BigInteger> FundsByBidderQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var fundsByBidderFunction = new FundsByBidderFunction();
                fundsByBidderFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<FundsByBidderFunction, BigInteger>(fundsByBidderFunction, blockParameter);
        }

        public Task<BigInteger> GetHighestBidQueryAsync(GetHighestBidFunction getHighestBidFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetHighestBidFunction, BigInteger>(getHighestBidFunction, blockParameter);
        }

        
        public Task<BigInteger> GetHighestBidQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetHighestBidFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> HighestBidderQueryAsync(HighestBidderFunction highestBidderFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HighestBidderFunction, string>(highestBidderFunction, blockParameter);
        }

        
        public Task<string> HighestBidderQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HighestBidderFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> HighestBindingBidQueryAsync(HighestBindingBidFunction highestBindingBidFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HighestBindingBidFunction, BigInteger>(highestBindingBidFunction, blockParameter);
        }

        
        public Task<BigInteger> HighestBindingBidQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HighestBindingBidFunction, BigInteger>(null, blockParameter);
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

        public Task<string> OperatorQueryAsync(OperatorFunction @operatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OperatorFunction, string>(@operatorFunction, blockParameter);
        }

        
        public Task<string> OperatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OperatorFunction, string>(null, blockParameter);
        }

        public Task<bool> OwnerHasWithdrawnQueryAsync(OwnerHasWithdrawnFunction ownerHasWithdrawnFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerHasWithdrawnFunction, bool>(ownerHasWithdrawnFunction, blockParameter);
        }

        
        public Task<bool> OwnerHasWithdrawnQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerHasWithdrawnFunction, bool>(null, blockParameter);
        }

        public Task<string> PayoutToSellerRequestAsync(PayoutToSellerFunction payoutToSellerFunction)
        {
             return ContractHandler.SendRequestAsync(payoutToSellerFunction);
        }

        public Task<TransactionReceipt> PayoutToSellerRequestAndWaitForReceiptAsync(PayoutToSellerFunction payoutToSellerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(payoutToSellerFunction, cancellationToken);
        }

        public Task<string> PayoutToSellerRequestAsync(BigInteger withdrawalAmount)
        {
            var payoutToSellerFunction = new PayoutToSellerFunction();
                payoutToSellerFunction.WithdrawalAmount = withdrawalAmount;
            
             return ContractHandler.SendRequestAsync(payoutToSellerFunction);
        }

        public Task<TransactionReceipt> PayoutToSellerRequestAndWaitForReceiptAsync(BigInteger withdrawalAmount, CancellationTokenSource cancellationToken = null)
        {
            var payoutToSellerFunction = new PayoutToSellerFunction();
                payoutToSellerFunction.WithdrawalAmount = withdrawalAmount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(payoutToSellerFunction, cancellationToken);
        }

        public Task<string> PlaceBidRequestAsync(PlaceBidFunction placeBidFunction)
        {
             return ContractHandler.SendRequestAsync(placeBidFunction);
        }

        public Task<string> PlaceBidRequestAsync()
        {
             return ContractHandler.SendRequestAsync<PlaceBidFunction>();
        }

        public Task<TransactionReceipt> PlaceBidRequestAndWaitForReceiptAsync(PlaceBidFunction placeBidFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(placeBidFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PlaceBidRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<PlaceBidFunction>(null, cancellationToken);
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

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }
    }
}
