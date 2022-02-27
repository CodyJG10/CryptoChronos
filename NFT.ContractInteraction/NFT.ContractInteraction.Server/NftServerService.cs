using NFT.ContractInteraction.Server.Interfaces;

namespace NFT.ContractInteraction.Server
{
    public class NftServerService
    {
        public INftController NftController { get; private set; }
        public IEscrowController EscrowController { get; private set;}
        public StorageHelper Storage { get; set; }

        public NftServerService(INftController nftController,
            StorageHelper storageHelper,
            IEscrowController escrowController)
        {
            NftController = nftController;
            Storage = storageHelper;
            EscrowController = escrowController;
        }
    }
}