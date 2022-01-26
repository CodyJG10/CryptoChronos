﻿using Microsoft.Extensions.Configuration;
using Nethereum.ABI.Model;
using NFT.ContractInteraction.Client.Interfaces;
using System.Numerics;

namespace NFT.ContractInteraction.Client.Implementations
{
    public class NftController : INftController
    {
        private TransactionHandler _transactionHandler;
        private IConfiguration _config;

        public NftController(TransactionHandler transactionHandler, IConfiguration config)
        {
            _transactionHandler = transactionHandler;
            _config = config;
        }

        public async Task<string> ApproveForTranser(string approveAddress, string tokenId)
        {
            var inputsParameters = new[] {
                        new Parameter("address", "to"),
                        new Parameter("uint256", "tokenId"),
                    };

            string nftAddress = _config["NftAddress"];

            var receipt = await _transactionHandler.SendTransactionAndWaitForReceipt("approve", nftAddress, 0, inputsParameters,
                approveAddress,
                BigInteger.Parse(tokenId));

            return receipt.TransactionHash;
        }

        public async Task<string> TransferNft(string toAddress, string tokenId, string contractAddress)
        {
            var userAddress = await _transactionHandler.GetSelectedAddress();
            var inputsParameters = new[] {
                        new Parameter("address", "from"),
                        new Parameter("address", "to"),
                        new Parameter("uint256", "tokenId"),
                    };

            var receipt = await _transactionHandler.SendTransactionAndWaitForReceipt("safeTransferFrom", contractAddress, 0, inputsParameters,
                userAddress,
                toAddress,
                BigInteger.Parse(tokenId));


            return receipt.TransactionHash;
        }

    }
}