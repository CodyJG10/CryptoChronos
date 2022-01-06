using CryptoChronos.Shared.Enums;
using CryptoChronos.Shared.Models;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Eth.Transactions;
using NFT.ContractInteraction.Server.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Watches.Contracts.EscrowManager;
using Watches.Contracts.EscrowManager.ContractDefinition;
using Watches.Contracts.NftEscrow;

namespace NFT.ContractInteraction.Server.Implementations
{
    public class EscrowController : IEscrowController
    {
        private readonly NethereumClient _client;

        public EscrowController(NethereumClient client)
        {
            _client = client;
        }


        public async Task<List<string>> GetAllEscrowContracts()
        {
            EscrowManagerService service = new EscrowManagerService(_client.Web3, _client.EscrowContractAddress);
            int totalContracts = int.Parse((await service.TotalContractsQueryAsync()).ToString());
            List<string> contracts = new List<string>();
            for(int i = 0; i < totalContracts; i++)
            {
                var contract = await service.EscrowContractsQueryAsync(i);
                contracts.Add(contract);
            }
            return contracts;
        }

        public async Task<List<string>> GetAllEscrowContractsForBuyer(string buyerAddress)
        {
            var allEscrows = await GetAllEscrowContracts();
            List<string> contracts = new List<string>();
            foreach (var escrowAddress in allEscrows)
            {
                NftEscrowService service = new NftEscrowService(_client.Web3, escrowAddress);
                var buyer = await service.BuyerAddressQueryAsync();
                if (buyer.ToLower() == buyerAddress.ToLower())
                {
                    contracts.Add(escrowAddress);
                }
            }
            return contracts;
        }

        public async Task<List<string>> GetAllEscrowContractsForSeller(string sellerAddress)
        {
            var allEscrows = await GetAllEscrowContracts();
            List<string> contracts = new List<string>();
            foreach (var escrowAddress in allEscrows)
            {
                NftEscrowService service = new NftEscrowService(_client.Web3, escrowAddress);
                var seller = await service.SellerAddressQueryAsync();
                if (seller.ToLower() == sellerAddress.ToLower())
                {
                    contracts.Add(escrowAddress);
                }
            }
            return contracts;
        }

        public async Task<EscrowContract> GetEscrowContract(string address)
        {
            NftEscrowService service = new NftEscrowService(_client.Web3, address);
            EscrowStatus state = (EscrowStatus)await service.ProjectStateQueryAsync();
            string? sellerAddress = await service.SellerAddressQueryAsync();
            string? buyerAddress = await service.BuyerAddressQueryAsync();
            string tokenId = "";
            if(state != EscrowStatus.NEW_ESCROW)
                tokenId = (await service.TokenIDQueryAsync()).ToString();
            EscrowContract contract = new EscrowContract()
            {
                Buyer = buyerAddress,
                Seller = sellerAddress,
                ContractAddress = address,
                State = (EscrowStatus)state,
                TokenId = tokenId,
                Link = "/Escrow/" + address,
                Watch = null
            };
            return contract;
        }

        public async Task<EscrowStatus> GetState(string address)
        {
            NftEscrowService service = new NftEscrowService(_client.Web3, address);
            var state = await service.ProjectStateQueryAsync();
            return (EscrowStatus)state;
        }

        public async Task<string> GetEscrowAddressFromTransaction(string txHash, string ownerAddress)
        {
            NftEscrowService service = new NftEscrowService(_client.Web3, _client.EscrowContractAddress);
            async Task<TransactionReceipt> GetTransactionReceipt(string txHash, int interval = 1000)
            {
                EthGetTransactionReceipt getTransactionReceipt = new EthGetTransactionReceipt(_client.Web3.Client);
                TransactionReceipt? receipt = null;
                while (receipt == null)
                {
                    receipt = await getTransactionReceipt.SendRequestAsync(txHash);
                    Thread.Sleep(interval);
                }
                return receipt;
            }

            var receipt = await GetTransactionReceipt(txHash);
            var eventOutput = receipt.DecodeAllEvents<EscrowCreatedEventDTO>();
            var output = eventOutput.Single(x => x.Event.Owner.ToLower() == ownerAddress.ToLower());
            return output.Event.ContractAddress;
        }
    }
}