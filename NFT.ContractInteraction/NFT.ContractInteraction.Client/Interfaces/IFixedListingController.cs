using CryptoChronos.Shared.Models;

namespace NFT.ContractInteraction.Client.Interfaces
{
    public interface IFixedListingController
    {
        public Task<string> Purchase(string listingAddress, FixedListing listing);
    }
}