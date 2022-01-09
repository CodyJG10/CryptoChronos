using CryptoChronos.Shared.Models;
using Nethereum.ABI.Model;
using NFT.ContractInteraction.Client.Interfaces;
using System.Numerics;

namespace NFT.ContractInteraction.Client.Implementations
{
    public class FixedListingController : IFixedListingController
    {
        private readonly TransactionHandler _transactionHandler;

        public FixedListingController(TransactionHandler transactionHandler)
        {
            _transactionHandler = transactionHandler;
        }

        public async Task<string> Purchase(string listingAddress, FixedListing listing)
        {
            BigInteger price = BigInteger.Parse(listing.Price);
            var receipt = await _transactionHandler.SendTransactionAndWaitForReceipt("purchase", listingAddress, price, new List<Parameter>().ToArray());
            return receipt.TransactionHash;
        }
    }
}
