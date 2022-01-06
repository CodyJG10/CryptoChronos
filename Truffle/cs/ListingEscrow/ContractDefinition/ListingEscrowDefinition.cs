using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Watches.Contracts.ListingEscrow.ContractDefinition
{


    public partial class ListingEscrowDeployment : ListingEscrowDeploymentBase
    {
        public ListingEscrowDeployment() : base(BYTECODE) { }
        public ListingEscrowDeployment(string byteCode) : base(byteCode) { }
    }

    public class ListingEscrowDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b5060405161090038038061090083398101604081905261002f91610096565b600180546001600160a01b03199081166001600160a01b03968716179091556002959095556003919091556000805485169184169190911790556004805490931691161790556100ed565b80516001600160a01b038116811461009157600080fd5b919050565b600080600080600060a086880312156100ae57600080fd5b855194506100be6020870161007a565b93506100cc6040870161007a565b9250606086015191506100e16080870161007a565b90509295509295909350565b610804806100fc6000396000f3fe60806040526004361061007b5760003560e01c80639b5b9b181161004e5780639b5b9b1814610130578063a035b1fe14610150578063c19d93fb14610166578063ea8a1af01461019457600080fd5b806308551a5314610080578063150b7a02146100bd57806317d70f7c1461010257806364edfbf014610126575b600080fd5b34801561008c57600080fd5b506001546100a0906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b3480156100c957600080fd5b506100e96100d836600461065f565b630a85bd0160e11b95945050505050565b6040516001600160e01b031990911681526020016100b4565b34801561010e57600080fd5b5061011860035481565b6040519081526020016100b4565b61012e6101a9565b005b34801561013c57600080fd5b5061012e61014b3660046106fe565b6103ff565b34801561015c57600080fd5b5061011860025481565b34801561017257600080fd5b5060045461018790600160a01b900460ff1681565b6040516100b4919061072a565b3480156101a057600080fd5b5061012e6104ef565b6002543410156101f15760405162461bcd60e51b815260206004820152600f60248201526e496e636f727265637420707269636560881b604482015260640160405180910390fd5b600054600354604051632142170760e11b815230600482015233602482015260448101919091526001600160a01b03909116906342842e0e90606401600060405180830381600087803b15801561024757600080fd5b505af115801561025b573d6000803e3d6000fd5b50505050600034905061026c6105cd565b1561036e576000805460035460405163152a902d60e11b815260048101919091526024810184905282916001600160a01b031690632a55205a906044016040805180830381865afa1580156102c5573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906102e99190610752565b60405191935091506001600160a01b0383169082156108fc029083906000818181858888f19350505050158015610324573d6000803e3d6000fd5b506001546001600160a01b03166108fc61033e8334610780565b6040518115909202916000818181858888f19350505050158015610366573d6000803e3d6000fd5b5050506103a9565b6001546040516001600160a01b03909116903480156108fc02916000818181858888f193505050501580156103a7573d6000803e3d6000fd5b505b6004805460ff60a01b1916600160a01b908117918290556040517f551dc40198cc79684bb69e4931dba4ac16e4598792ee1c0a5000aeea366d7bb6926103f492900460ff169061072a565b60405180910390a150565b6004546001600160a01b0316331461041657600080fd5b600080546001600160a01b0319166001600160a01b03848116918217909255600383905560048054604051632142170760e11b815293169083015230602483015260448201839052906342842e0e90606401600060405180830381600087803b15801561048257600080fd5b505af1158015610496573d6000803e3d6000fd5b50506004805460ff60a01b1916908190556040517f551dc40198cc79684bb69e4931dba4ac16e4598792ee1c0a5000aeea366d7bb693506104e39250600160a01b90910460ff169061072a565b60405180910390a15050565b6001546001600160a01b0316331461050657600080fd5b600054600354604051632142170760e11b815230600482015233602482015260448101919091526001600160a01b03909116906342842e0e90606401600060405180830381600087803b15801561055c57600080fd5b505af1158015610570573d6000803e3d6000fd5b50506004805460ff60a01b1916600160a11b17908190556040517f551dc40198cc79684bb69e4931dba4ac16e4598792ee1c0a5000aeea366d7bb693506105c39250600160a01b90910460ff169061072a565b60405180910390a1565b600080546040516301ffc9a760e01b815263152a902d60e11b600482015282916001600160a01b0316906301ffc9a790602401602060405180830381865afa15801561061d573d6000803e3d6000fd5b505050506040513d601f19601f8201168201806040525081019061064191906107a5565b92915050565b6001600160a01b038116811461065c57600080fd5b50565b60008060008060006080868803121561067757600080fd5b853561068281610647565b9450602086013561069281610647565b935060408601359250606086013567ffffffffffffffff808211156106b657600080fd5b818801915088601f8301126106ca57600080fd5b8135818111156106d957600080fd5b8960208285010111156106eb57600080fd5b9699959850939650602001949392505050565b6000806040838503121561071157600080fd5b823561071c81610647565b946020939093013593505050565b602081016003831061074c57634e487b7160e01b600052602160045260246000fd5b91905290565b6000806040838503121561076557600080fd5b825161077081610647565b6020939093015192949293505050565b6000828210156107a057634e487b7160e01b600052601160045260246000fd5b500390565b6000602082840312156107b757600080fd5b815180151581146107c757600080fd5b939250505056fea2646970667358221220c7b5cbce932c46f10e41d7f0d1ac1df4ddeca8ac0e52e246c42a859d6cfc4c5964736f6c634300080b0033";
        public ListingEscrowDeploymentBase() : base(BYTECODE) { }
        public ListingEscrowDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "_price", 1)]
        public virtual BigInteger Price { get; set; }
        [Parameter("address", "_seller", 2)]
        public virtual string Seller { get; set; }
        [Parameter("address", "_operator", 3)]
        public virtual string Operator { get; set; }
        [Parameter("uint256", "_tokenId", 4)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "_nftAddress", 5)]
        public virtual string NftAddress { get; set; }
    }

    public partial class CancelFunction : CancelFunctionBase { }

    [Function("cancel")]
    public class CancelFunctionBase : FunctionMessage
    {

    }

    public partial class DepositNFTFunction : DepositNFTFunctionBase { }

    [Function("depositNFT")]
    public class DepositNFTFunctionBase : FunctionMessage
    {
        [Parameter("address", "_NFTAddress", 1)]
        public virtual string NFTAddress { get; set; }
        [Parameter("uint256", "_TokenID", 2)]
        public virtual BigInteger TokenID { get; set; }
    }

    public partial class OnERC721ReceivedFunction : OnERC721ReceivedFunctionBase { }

    [Function("onERC721Received", "bytes4")]
    public class OnERC721ReceivedFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("address", "from", 2)]
        public virtual string From { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class PriceFunction : PriceFunctionBase { }

    [Function("price", "uint256")]
    public class PriceFunctionBase : FunctionMessage
    {

    }

    public partial class PurchaseFunction : PurchaseFunctionBase { }

    [Function("purchase")]
    public class PurchaseFunctionBase : FunctionMessage
    {

    }

    public partial class SellerFunction : SellerFunctionBase { }

    [Function("seller", "address")]
    public class SellerFunctionBase : FunctionMessage
    {

    }

    public partial class StateFunction : StateFunctionBase { }

    [Function("state", "uint8")]
    public class StateFunctionBase : FunctionMessage
    {

    }

    public partial class TokenIdFunction : TokenIdFunctionBase { }

    [Function("tokenId", "uint256")]
    public class TokenIdFunctionBase : FunctionMessage
    {

    }

    public partial class StateChangedEventDTO : StateChangedEventDTOBase { }

    [Event("StateChanged")]
    public class StateChangedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "_state", 1, false )]
        public virtual byte State { get; set; }
    }







    public partial class PriceOutputDTO : PriceOutputDTOBase { }

    [FunctionOutput]
    public class PriceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class SellerOutputDTO : SellerOutputDTOBase { }

    [FunctionOutput]
    public class SellerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class StateOutputDTO : StateOutputDTOBase { }

    [FunctionOutput]
    public class StateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class TokenIdOutputDTO : TokenIdOutputDTOBase { }

    [FunctionOutput]
    public class TokenIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
