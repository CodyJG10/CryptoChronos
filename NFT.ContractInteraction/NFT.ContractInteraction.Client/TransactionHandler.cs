using Nethereum.ABI.Model;
using Nethereum.RPC.Eth.DTOs;
using System.Numerics;

namespace NFT.ContractInteraction.Client
{
    public abstract class TransactionHandler
    {
        public abstract Task<TransactionReceipt> SendTransactionAndWaitForReceipt
            (string funcName,
            string contractAddress,
            BigInteger value,
            Parameter[] inputParams,
            params object[] values);

        public abstract Task<TransactionReceipt> SendTransactionAndWaitForReceipt
            (string funcName,
            string contractAddress,
            BigInteger value,
            Parameter[] inputParams,
            int interval = 1000,
            params object[] values
            );

        protected abstract Task<TransactionReceipt> GetTransactionReceipt(string txHash, int interval = 1000);

        public abstract Task<string> GetSelectedAddress();

        public abstract Task<bool> IsSiteConnected();
    }
}