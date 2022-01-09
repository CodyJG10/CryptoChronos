using NFT.ContractInteraction.Client.Interfaces;

namespace NFT.ContractInteraction.Client
{
    public class NftClientService
    {
        public IAuctionController AuctionController { get; set; }
        public IFixedListingController ListingController { get; set; }
        public INftController NftController { get; set; }
        public IEscrowController EscrowController { get; set; }
        public TransactionHandler TransactionHandler { get; set; }

        public NftClientService(IAuctionController auctionController,
            IFixedListingController listingController,
            INftController nftController,
            TransactionHandler transactionHandler, IEscrowController escrowController)
        {
            TransactionHandler = transactionHandler;
            AuctionController = auctionController;
            ListingController = listingController;
            NftController = nftController;
            EscrowController = escrowController;
        }
    }
}
