using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using CryptoChronos.Shared.Services;
using Newtonsoft.Json;

namespace CryptoChronos.Client.Util
{
    public static class ShopUtils
    {
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