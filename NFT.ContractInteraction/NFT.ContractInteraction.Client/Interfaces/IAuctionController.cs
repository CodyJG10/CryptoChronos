namespace NFT.ContractInteraction.Client.Interfaces
{
    public interface IAuctionController
    {
        public Task<string> PlaceBid(string amountInWei, string auctionAddress);
        public Task<string> Withdraw(string address);
    }
}
