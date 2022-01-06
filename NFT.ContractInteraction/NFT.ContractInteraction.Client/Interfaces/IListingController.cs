using CryptoChronos.Shared.Models;

namespace NFT.ContractInteraction.Client.Interfaces
{
    public interface IListingController
    {
        public Task<string> Purchase(string listingAddress, FixedListing listing);
    }
}