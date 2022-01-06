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

namespace Watches.Contracts.NftEscrow.ContractDefinition
{


    public partial class NftEscrowDeployment : NftEscrowDeploymentBase
    {
        public NftEscrowDeployment() : base(BYTECODE) { }
        public NftEscrowDeployment(string byteCode) : base(byteCode) { }
    }

    public class NftEscrowDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060408190526004805461ffff19169055610a933881900390819083398101604081905261002d9161009f565b600080546001600160a01b0319166001600160a01b038481169190911790915581161561007057600180546001600160a01b0319166001600160a01b0383161790555b50506004805462ff0000191690556100d2565b80516001600160a01b038116811461009a57600080fd5b919050565b600080604083850312156100b257600080fd5b6100bb83610083565b91506100c960208401610083565b90509250929050565b6109b2806100e16000396000f3fe6080604052600436106100c25760003560e01c80635bf8633a1161007f5780639b5b9b18116100595780639b5b9b1814610205578063a1ee418114610225578063a5c42ef11461023a578063f6326fb31461025057600080fd5b80635bf8633a146101b05780635e10177b146101d0578063748807ab146101d857600080fd5b806312065fe0146100c7578063150b7a02146100e95780632f9fa7f61461012e578063342901a7146101455780633d9b2ae61461015857806344834aca14610190575b600080fd5b3480156100d357600080fd5b50475b6040519081526020015b60405180910390f35b3480156100f557600080fd5b5061011561010436600461082c565b630a85bd0160e11b95945050505050565b6040516001600160e01b031990911681526020016100e0565b34801561013a57600080fd5b50610143610258565b005b6101436101533660046108c7565b610363565b34801561016457600080fd5b50600054610178906001600160a01b031681565b6040516001600160a01b0390911681526020016100e0565b34801561019c57600080fd5b50600154610178906001600160a01b031681565b3480156101bc57600080fd5b50600254610178906001600160a01b031681565b61014361051d565b3480156101e457600080fd5b506004546101f89062010000900460ff1681565b6040516100e09190610906565b34801561021157600080fd5b5061014361022036600461092e565b61061d565b34801561023157600080fd5b5061014361072e565b34801561024657600080fd5b506100d660035481565b6101436107ab565b60018060045462010000900460ff166006811115610278576102786108f0565b1461028257600080fd5b6000546001600160a01b0316331461029957600080fd5b600254600354604051632142170760e11b81526001600160a01b03909216916342842e0e916102ce9130913391600401610958565b600060405180830381600087803b1580156102e857600080fd5b505af11580156102fc573d6000803e3d6000fd5b5050600480546002935090915062ff0000191662010000835b02179055507f23ad33ab6a13a00aa7d06cd167b2abd03dec86af3cf3cc91759dcd3ae8411887600460029054906101000a900460ff166040516103589190610906565b60405180910390a150565b60038060045462010000900460ff166006811115610383576103836108f0565b1461038d57600080fd5b6001546001600160a01b03163314806103b057506000546001600160a01b031633145b6103b957600080fd5b6000546001600160a01b03163314156103e4576004805461ff001916610100841515021790556103f3565b6004805460ff19168315151790555b60045460ff6101009091041615156001148015610417575060045460ff1615156001145b1561051957600254600054600354604051632142170760e11b81526001600160a01b03938416936342842e0e936104579330939290911691600401610958565b600060405180830381600087803b15801561047157600080fd5b505af1158015610485573d6000803e3d6000fd5b50506001546040516001600160a01b0390911692504780156108fc029250906000818181858888f193505050501580156104c3573d6000803e3d6000fd5b506004805462ff000019166204000017908190556040517f23ad33ab6a13a00aa7d06cd167b2abd03dec86af3cf3cc91759dcd3ae841188791610510916201000090910460ff1690610906565b60405180910390a15b5050565b60058060045462010000900460ff16600681111561053d5761053d6108f0565b1461054757600080fd5b6001546001600160a01b0316331461055e57600080fd5b600254600154600354604051632142170760e11b81526001600160a01b03938416936342842e0e936105999330939290911691600401610958565b600060405180830381600087803b1580156105b357600080fd5b505af11580156105c7573d6000803e3d6000fd5b5050600080546040516001600160a01b0390911693504780156108fc02935091818181858888f19350505050158015610604573d6000803e3d6000fd5b50600480546006919062ff000019166201000083610315565b60008060045462010000900460ff16600681111561063d5761063d6108f0565b1461064757600080fd5b6000546001600160a01b0316331461065e57600080fd5b600280546001600160a01b0319166001600160a01b0385169081179091556003839055604051632142170760e11b81526342842e0e906106a690339030908790600401610958565b600060405180830381600087803b1580156106c057600080fd5b505af11580156106d4573d6000803e3d6000fd5b50506004805462ff0000191662010000908117918290556040517f23ad33ab6a13a00aa7d06cd167b2abd03dec86af3cf3cc91759dcd3ae841188794506107219350910460ff1690610906565b60405180910390a1505050565b60038060045462010000900460ff16600681111561074e5761074e6108f0565b1461075857600080fd5b6000546001600160a01b0316331461076f57600080fd5b60045460ff1615801561078a5750600454610100900460ff16155b61079357600080fd5b600480546005919062ff000019166201000083610315565b60018060045462010000900460ff1660068111156107cb576107cb6108f0565b146107d557600080fd5b6001546001600160a01b03166107f857600180546001600160a01b031916331790555b600480546003919062ff000019166201000083610315565b80356001600160a01b038116811461082757600080fd5b919050565b60008060008060006080868803121561084457600080fd5b61084d86610810565b945061085b60208701610810565b935060408601359250606086013567ffffffffffffffff8082111561087f57600080fd5b818801915088601f83011261089357600080fd5b8135818111156108a257600080fd5b8960208285010111156108b457600080fd5b9699959850939650602001949392505050565b6000602082840312156108d957600080fd5b813580151581146108e957600080fd5b9392505050565b634e487b7160e01b600052602160045260246000fd5b602081016007831061092857634e487b7160e01b600052602160045260246000fd5b91905290565b6000806040838503121561094157600080fd5b61094a83610810565b946020939093013593505050565b6001600160a01b03938416815291909216602082015260408101919091526060019056fea26469706673582212204c833d081f2d35cc36a231ffaca8651c5688698e35e64a1f493978f625c55c6364736f6c634300080b0033";
        public NftEscrowDeploymentBase() : base(BYTECODE) { }
        public NftEscrowDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
        [Parameter("address", "buyer", 2)]
        public virtual string Buyer { get; set; }
    }

    public partial class BuyerAddressFunction : BuyerAddressFunctionBase { }

    [Function("buyerAddress", "address")]
    public class BuyerAddressFunctionBase : FunctionMessage
    {

    }

    public partial class CancelAtNFTFunction : CancelAtNFTFunctionBase { }

    [Function("cancelAtNFT")]
    public class CancelAtNFTFunctionBase : FunctionMessage
    {

    }

    public partial class CancelBeforeDeliveryFunction : CancelBeforeDeliveryFunctionBase { }

    [Function("cancelBeforeDelivery")]
    public class CancelBeforeDeliveryFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_state", 1)]
        public virtual bool State { get; set; }
    }

    public partial class ConfirmDeliveryFunction : ConfirmDeliveryFunctionBase { }

    [Function("confirmDelivery")]
    public class ConfirmDeliveryFunctionBase : FunctionMessage
    {

    }

    public partial class DepositETHFunction : DepositETHFunctionBase { }

    [Function("depositETH")]
    public class DepositETHFunctionBase : FunctionMessage
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

    public partial class GetBalanceFunction : GetBalanceFunctionBase { }

    [Function("getBalance", "uint256")]
    public class GetBalanceFunctionBase : FunctionMessage
    {

    }

    public partial class InitiateDeliveryFunction : InitiateDeliveryFunctionBase { }

    [Function("initiateDelivery")]
    public class InitiateDeliveryFunctionBase : FunctionMessage
    {

    }

    public partial class NftAddressFunction : NftAddressFunctionBase { }

    [Function("nftAddress", "address")]
    public class NftAddressFunctionBase : FunctionMessage
    {

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

    public partial class ProjectStateFunction : ProjectStateFunctionBase { }

    [Function("projectState", "uint8")]
    public class ProjectStateFunctionBase : FunctionMessage
    {

    }

    public partial class SellerAddressFunction : SellerAddressFunctionBase { }

    [Function("sellerAddress", "address")]
    public class SellerAddressFunctionBase : FunctionMessage
    {

    }

    public partial class TokenIDFunction : TokenIDFunctionBase { }

    [Function("tokenID", "uint256")]
    public class TokenIDFunctionBase : FunctionMessage
    {

    }

    public partial class StateUpdatedEventDTO : StateUpdatedEventDTOBase { }

    [Event("StateUpdated")]
    public class StateUpdatedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "state", 1, false )]
        public virtual byte State { get; set; }
    }

    public partial class BuyerAddressOutputDTO : BuyerAddressOutputDTOBase { }

    [FunctionOutput]
    public class BuyerAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }











    public partial class GetBalanceOutputDTO : GetBalanceOutputDTOBase { }

    [FunctionOutput]
    public class GetBalanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "balance", 1)]
        public virtual BigInteger Balance { get; set; }
    }



    public partial class NftAddressOutputDTO : NftAddressOutputDTOBase { }

    [FunctionOutput]
    public class NftAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ProjectStateOutputDTO : ProjectStateOutputDTOBase { }

    [FunctionOutput]
    public class ProjectStateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class SellerAddressOutputDTO : SellerAddressOutputDTOBase { }

    [FunctionOutput]
    public class SellerAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenIDOutputDTO : TokenIDOutputDTOBase { }

    [FunctionOutput]
    public class TokenIDOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
