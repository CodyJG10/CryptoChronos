using MetaMask.Blazor;
using Microsoft.Extensions.Configuration;
using Nethereum.ABI.FunctionEncoding;
using Nethereum.ABI.Model;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.RPC.Eth.Transactions;
using Nethereum.Web3;
using System.Numerics;

namespace NFT.ContractInteraction.Client.Transactions
{
    public class MetaMaskTransactionHandler : TransactionHandler
    {
        protected MetaMaskService _metaMask;
        private string _url;

        public MetaMaskTransactionHandler(MetaMaskService metaMask, IConfiguration config)
        {
            _metaMask = metaMask;
            _url = config["URL"];
        }

        private async Task<string> CallFunction(string funcName, string contractAddress, BigInteger valueInWei, Parameter[] paramaters, params object[] values)
        {
            FunctionABI function = new FunctionABI(funcName, false);

            function.InputParameters = paramaters;
            var functionCallEncoder = new FunctionCallEncoder();

            var data = functionCallEncoder.EncodeRequest(function.Sha3Signature, paramaters,
                values);

            data = data[2..];
            var result = await _metaMask.SendTransaction(contractAddress, valueInWei, data);

            return result;
        }

        protected override async Task<TransactionReceipt> GetTransactionReceipt(string txHash, int interval = 1000)
        {
            EthGetTransactionReceipt getTransactionReceipt = new EthGetTransactionReceipt(new Web3(_url).Client);
            TransactionReceipt? receipt = null;
            while (receipt == null)
            {
                receipt = await getTransactionReceipt.SendRequestAsync(txHash);
                Thread.Sleep(interval);
            }
            return receipt;
        }

        public override async Task<TransactionReceipt> SendTransactionAndWaitForReceipt
            (
            string funcName,
            string contractAddress,
            BigInteger value,
            Parameter[] inputParams,
            params object[] values
            )
        {
            var txHash = await CallFunction(funcName, contractAddress, value, inputParams, values);
            var receipt = await GetTransactionReceipt(txHash);
            return receipt;
        }

        public override async Task<TransactionReceipt> SendTransactionAndWaitForReceipt
            (
            string funcName,
            string contractAddress,
            BigInteger value,
            Parameter[] inputParams,
            int interval = 1000,
            params object[] values
            )
        {
            var txHash = await CallFunction(funcName, contractAddress, value, inputParams, values);
            return await GetTransactionReceipt(txHash, interval);
        }

        public override async Task<string> GetSelectedAddress() => await _metaMask.GetSelectedAddress();

        public override async Task<bool> IsSiteConnected()
        {
            return await _metaMask.IsSiteConnected();
        }
    }
}
