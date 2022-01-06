using NFT.ContractInteraction.Server.Interfaces;

namespace NFT.ContractInteraction.Server
{
    public class NftServerService
    {
        public INftController NftController { get; private set; }
        public IAuctionController AuctionController { get; private set; }
        public IListingController ListingController { get; private set; }
        public IEscrowController EscrowController { get; private set;}
        public StorageHelper Storage { get; set; }

        public NftServerService(INftController nftController,
            IAuctionController auctionController,
            IListingController listingController,
            StorageHelper storageHelper,
            IEscrowController escrowController)
        {
            NftController = nftController;
            AuctionController = auctionController;
            ListingController = listingController;
            Storage = storageHelper;
            EscrowController = escrowController;
        }
    }
}