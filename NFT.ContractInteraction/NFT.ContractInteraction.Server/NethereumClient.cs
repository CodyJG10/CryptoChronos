using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using System.Numerics;

namespace NFT.ContractInteraction.Server
{
    /**
     *  Stores information about Web3
     */
    public class NethereumClient
    {
        public Web3 Web3 { get; private set; }
        public string EscrowContractAddress { get; private set; }
        public string NftAddress { get; private set; }
        public string BlockchainUrl { get; private set; }
        public BigInteger ChainId { get; private set; }
        public string ListingFactoryAddress { get; private set; }
        public string AuctionFactoryAddress { get; private set; }

        public NethereumClient(string ownerPrivateKey,
            string chainId,
            string escrowManagerAddress,
            string auctionFactoryAddress,
            string nftAddress,
            string url,
            string listingFactoryAddress)
        {
            ChainId = BigInteger.Parse(chainId);
            EscrowContractAddress = escrowManagerAddress;
            AuctionFactoryAddress = auctionFactoryAddress;
            NftAddress = nftAddress;
            BlockchainUrl = url;
            ListingFactoryAddress = listingFactoryAddress;
            Account account = new Account(ownerPrivateKey, ChainId);
            Web3 = new Web3(account, BlockchainUrl);
        }
    }
}
