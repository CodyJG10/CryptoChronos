using Nethereum.Contracts.ContractHandlers;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;
using Watches.Contracts.EscrowManager.ContractDefinition;

namespace Watches.Contracts.EscrowManager
{
    public partial class EscrowManagerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, EscrowManagerDeployment escrowManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<EscrowManagerDeployment>().SendRequestAndWaitForReceiptAsync(escrowManagerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, EscrowManagerDeployment escrowManagerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<EscrowManagerDeployment>().SendRequestAsync(escrowManagerDeployment);
        }

        public static async Task<EscrowManagerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, EscrowManagerDeployment escrowManagerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, escrowManagerDeployment, cancellationTokenSource);
            return new EscrowManagerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public EscrowManagerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddNewEscrowRequestAsync(AddNewEscrowFunction addNewEscrowFunction)
        {
            return ContractHandler.SendRequestAsync(addNewEscrowFunction);
        }

        public Task<string> AddNewEscrowRequestAsync()
        {
            return ContractHandler.SendRequestAsync<AddNewEscrowFunction>();
        }

        public Task<TransactionReceipt> AddNewEscrowRequestAndWaitForReceiptAsync(AddNewEscrowFunction addNewEscrowFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewEscrowFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AddNewEscrowRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<AddNewEscrowFunction>(null, cancellationToken);
        }

        public Task<string> AddNewEscrowRequestAsync(AddNewEscrow1Function addNewEscrow1Function)
        {
            return ContractHandler.SendRequestAsync(addNewEscrow1Function);
        }

        public Task<TransactionReceipt> AddNewEscrowRequestAndWaitForReceiptAsync(AddNewEscrow1Function addNewEscrow1Function, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewEscrow1Function, cancellationToken);
        }

        public Task<string> AddNewEscrowRequestAsync(string buyer)
        {
            var addNewEscrow1Function = new AddNewEscrow1Function();
            addNewEscrow1Function.Buyer = buyer;

            return ContractHandler.SendRequestAsync(addNewEscrow1Function);
        }

        public Task<TransactionReceipt> AddNewEscrowRequestAndWaitForReceiptAsync(string buyer, CancellationTokenSource cancellationToken = null)
        {
            var addNewEscrow1Function = new AddNewEscrow1Function();
            addNewEscrow1Function.Buyer = buyer;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addNewEscrow1Function, cancellationToken);
        }

        public Task<string> EscrowContractsQueryAsync(EscrowContractsFunction escrowContractsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EscrowContractsFunction, string>(escrowContractsFunction, blockParameter);
        }


        public Task<string> EscrowContractsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var escrowContractsFunction = new EscrowContractsFunction();
            escrowContractsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<EscrowContractsFunction, string>(escrowContractsFunction, blockParameter);
        }

        public Task<BigInteger> TotalContractsQueryAsync(TotalContractsFunction totalContractsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalContractsFunction, BigInteger>(totalContractsFunction, blockParameter);
        }


        public Task<BigInteger> TotalContractsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalContractsFunction, BigInteger>(null, blockParameter);
        }
    }
}
