using Microsoft.Extensions.Configuration;
using Nethereum.ABI.Model;
using NFT.ContractInteraction.Client.Interfaces;
using System.Numerics;

namespace NFT.ContractInteraction.Client.Implementations
{
    public class EscrowController : IEscrowController
    {
        private TransactionHandler _transactionHandler;
        private IConfiguration _config;

        public EscrowController(TransactionHandler transactionHandler, IConfiguration config)
        {
            _transactionHandler = transactionHandler;
            _config = config; 
        }

        public async Task<string> ConfirmDelivery(string address)
            => (await _transactionHandler.SendTransactionAndWaitForReceipt("confirmDelivery", address, 0, new List<Parameter>().ToArray())).TransactionHash;

        public async Task<string> DeployNewEscrow()
        {
            string escrowManagerAddress = _config["EscrowManagerAddress"];
            var result = await _transactionHandler.SendTransactionAndWaitForReceipt("addNewEscrow", escrowManagerAddress, 0, new List<Parameter>().ToArray());
            return result.TransactionHash;
        }
        public async Task<string> DepositEth(string amount, string address)
            => (await _transactionHandler.SendTransactionAndWaitForReceipt("depositETH", address, BigInteger.Parse(amount), new List<Parameter>().ToArray())).TransactionHash;

        public async Task<string> DepositToken(string escrowAddress, string tokenId)
        {
            var inputsParameters = new[] {
                        new Parameter("address", "_NFTAddress"),
                        new Parameter("uint256", "_TokenID"),
                    };

            var receipt = await _transactionHandler.SendTransactionAndWaitForReceipt("depositNFT", escrowAddress, 0, inputsParameters,
                _config["NftAddress"],
                BigInteger.Parse(tokenId));


            return receipt.TransactionHash;
        }

        public async Task<string> InitiateDelivery(string address)
            => (await _transactionHandler.SendTransactionAndWaitForReceipt("initiateDelivery", address, 0, new List<Parameter>().ToArray())).TransactionHash;
    }
}
