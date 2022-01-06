﻿using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using CryptoChronos.Shared.Services;
using Newtonsoft.Json;

namespace CryptoChronos.Client.Util
{
    public static class ShopUtils
    {
        public struct TrendingSale
        {
            public string Title { get; set; }
            public string Seller { get; set; }
            public string Link { get; set; }
            public Watch Watch { get; set; }
            public string WatchImageUri { get; set; }
            public string Price { get; set; }
        }

        public static async Task<List<TrendingSale>> GetItemsAsync(IContractInteractionService server, IUserService userService)
        {
            var products = await server.GetAllProducts();
            List<TrendingSale> items = new List<TrendingSale>();
            foreach (var product in products)
            {
                var tokenUri = await server.GetTokenUri(product.TokenId);
                var watchJson = await server.GetNftMetadata(tokenUri);
                var watch = JsonConvert.DeserializeObject<Watch>(watchJson);

                var sellerName = product.SellerAddress;
                var user = await userService.GetUser(sellerName);
                if (user.Name != null)
                    sellerName = user.Name;
                bool isAuction = product is Auction;
                string link = isAuction ? "/Auction/" : "/Listing/";
                AuctionState state;
                if (isAuction)
                {
                    state = await server.GetAuctionState(product.Address);
                }
                else
                {
                    state = await server.GetListingState(product.Address);
                }

                if (state != AuctionState.ACTIVE)
                    continue;

                TrendingSale sale = new TrendingSale()
                {
                    Title = watch.Manufacturer + " " + watch.Model,
                    Seller = sellerName,
                    Link = link + product.Address,
                    WatchImageUri = "http://cloudflare-ipfs.com/ipfs/" + watch.ImageCID,
                    Watch = watch
                };
                items.Add(sale);
            }
            return items;
        }

        public static async Task<List<EscrowContract>> GetAllEscrowsForUser(string userAddress, IContractInteractionService server)
        {
            List<EscrowContract> escrowContainers = new List<EscrowContract>();
            List<string> allEscrows = new List<string>();

            (await server.GetEscrowContractsForSeller(userAddress)).ForEach(x => allEscrows.Add(x));
            (await server.GetEscrowContractsForBuyer(userAddress)).ForEach(x => allEscrows.Add(x));

            foreach (var escrowAddress in allEscrows)
            {
                try
                {
                    var state = await server.GetEscrowState(escrowAddress);
                    if (state == EscrowStatus.DELIVERED
                        || state == EscrowStatus.CANCELLED_BEFORE_DELIVERY
                        || state == EscrowStatus.CANCELLED_AT_NFT)
                        continue;
                    var escrowData = await server.GetEscrow(escrowAddress);
                    escrowData.Link = "/Escrow/" + escrowAddress;
                    var tokenUri = await server.GetTokenUri(escrowData.TokenId);
                    var watch = JsonConvert.DeserializeObject<Watch>(await server.GetNftMetadata(tokenUri));
                    escrowData.Watch = watch;
                    escrowContainers.Add(escrowData);
                }
                catch (Exception) { }
            }

            return escrowContainers;
        }
    }
}