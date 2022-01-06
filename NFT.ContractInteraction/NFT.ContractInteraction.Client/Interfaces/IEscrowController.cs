using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFT.ContractInteraction.Client.Interfaces
{
    public interface IEscrowController
    {
        public Task<string> DeployNewEscrow();
        public Task<string> DepositEth(string amount, string address);
        public Task<string> DepositToken(string escrowAddress, string tokenId);
        public Task<string> InitiateDelivery(string address);
        public Task<string> ConfirmDelivery(string address);
    }
}