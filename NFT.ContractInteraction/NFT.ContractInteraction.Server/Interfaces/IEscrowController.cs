using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFT.ContractInteraction.Server.Interfaces
{
    public interface IEscrowController
    {
        public Task<EscrowStatus> GetState(string address);
        public Task<List<string>> GetAllEscrowContracts();
        public Task<List<string>> GetAllEscrowContractsForBuyer(string buyerAddress);
        public Task<List<string>> GetAllEscrowContractsForSeller(string sellerAddress);
        public Task<EscrowContract> GetEscrowContract(string address);
        public Task<string> GetEscrowAddressFromTransaction(string txHash, string ownerAddress);
    }
}