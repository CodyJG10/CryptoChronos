const escrowManager = artifacts.require("EscrowManager");
const nft = artifacts.require("WatchNFT");
const listingFactory = artifacts.require("ListingFactory");
const auctionFactory = artifacts.require("AuctionFactory");


module.exports = function (deployer) {
  // deployer.deploy(escrowManager);
  deployer.deploy(nft);
  deployer.deploy(listingFactory);
  deployer.deploy(auctionFactory);
};