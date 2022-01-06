using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace WatchNFT.Server.Controllers
{
    public partial class ContractInteractionController
    {
        [HttpGet("EscrowState")]
        public async Task<EscrowStatus> GetEscrowState(string address)
           =>  await _nftService.EscrowController.GetState(address);
    
        [HttpGet("EscrowContracts")]
        public async Task<List<string>> GetEscrowContracts(string? buyerAddress = null, string? sellerAddress = null)
        {
            List<string> escrowAddresses = new List<string>();
            if(buyerAddress == null && sellerAddress == null)
            {
                escrowAddresses = await _nftService.EscrowController.GetAllEscrowContracts();
            }
            else
            {
                if(buyerAddress != null)
                {
                    escrowAddresses = await _nftService.EscrowController.GetAllEscrowContractsForBuyer(buyerAddress); 
                }
                else
                {
                    escrowAddresses = await _nftService.EscrowController.GetAllEscrowContractsForSeller(sellerAddress);
                }
            }
            return escrowAddresses;
        }

        [HttpGet("EscrowContract")]
        public async Task<EscrowContract> GetEscrowContract(string address)
            => await _nftService.EscrowController.GetEscrowContract(address);

        [HttpGet("EscrowAddress")]
        public async Task<string> GetEscrowAddress(string transaction, string owner)
            => await _nftService.EscrowController.GetEscrowAddressFromTransaction(transaction, owner);
    }
}