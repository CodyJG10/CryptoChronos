using NFT.ContractInteraction.Client.Interfaces;

namespace NFT.ContractInteraction.Client
{
    public class NftClientService
    {
        public INftController NftController { get; set; }
        public IEscrowController EscrowController { get; set; }
        public TransactionHandler TransactionHandler { get; set; }

        public NftClientService(
            INftController nftController,
            TransactionHandler transactionHandler, IEscrowController escrowController)
        {
            TransactionHandler = transactionHandler;
            NftController = nftController;
            EscrowController = escrowController;
        }
    }
}
