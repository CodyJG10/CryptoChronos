using Nethereum.ABI.Model;
using NFT.ContractInteraction.Client.Interfaces;
using System.Numerics;

namespace NFT.ContractInteraction.Client.Implementations
{
    public class AuctionController : IAuctionController
    {
        private TransactionHandler _transactionHandler;

        public AuctionController(TransactionHandler transactionHandler)
        {
            _transactionHandler = transactionHandler;
        }

        public async Task<string> PlaceBid(string amountInWei, string auctionAddress)
            => (await _transactionHandler.SendTransactionAndWaitForReceipt("placeBid", auctionAddress, BigInteger.Parse(amountInWei), new List<Parameter>().ToArray())).TransactionHash;

        public async Task<string> Withdraw(string address) => (await _transactionHandler.SendTransactionAndWaitForReceipt("withdraw", address, 0, new List<Parameter>().ToArray())).TransactionHash;
    }
}
