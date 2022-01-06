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

namespace Watches.Contracts.Auction.ContractDefinition
{


    public partial class AuctionDeployment : AuctionDeploymentBase
    {
        public AuctionDeployment() : base(BYTECODE) { }
        public AuctionDeployment(string byteCode) : base(byteCode) { }
    }

    public class AuctionDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50604051610d7a380380610d7a83398101604081905261002f9161007f565b600080546001600160a01b039384166001600160a01b031991821617909155600480549290931691161790556001556100bb565b80516001600160a01b038116811461007a57600080fd5b919050565b60008060006060848603121561009457600080fd5b835192506100a460208501610063565b91506100b260408501610063565b90509250925092565b610cb0806100ca6000396000f3fe6080604052600436106100f35760003560e01c806391f901571161008a578063c83dc3a311610059578063c83dc3a3146102c5578063ce10cf80146102e5578063ecfc7ecc14610312578063f5b56c561461031a57600080fd5b806391f901571461023f5780639b5b9b181461025f578063b3cc167a14610281578063c19d93fb1461029757600080fd5b80633ccfd60b116100c65780633ccfd60b146101c85780634979440a146101dd578063570ca7351461020a5780638fa8b7901461022a57600080fd5b806308551a53146100f8578063150b7a021461013557806317d70f7c1461017a5780631bf822e51461019e575b600080fd5b34801561010457600080fd5b50600054610118906001600160a01b031681565b6040516001600160a01b0390911681526020015b60405180910390f35b34801561014157600080fd5b50610161610150366004610a9f565b630a85bd0160e11b95945050505050565b6040516001600160e01b0319909116815260200161012c565b34801561018657600080fd5b5061019060025481565b60405190815260200161012c565b3480156101aa57600080fd5b506008546101b89060ff1681565b604051901515815260200161012c565b3480156101d457600080fd5b506101b8610330565b3480156101e957600080fd5b506006546001600160a01b0316600090815260076020526040902054610190565b34801561021657600080fd5b50600454610118906001600160a01b031681565b34801561023657600080fd5b506101b86105b0565b34801561024b57600080fd5b50600654610118906001600160a01b031681565b34801561026b57600080fd5b5061027f61027a366004610b3e565b610652565b005b34801561028d57600080fd5b5061019060015481565b3480156102a357600080fd5b506004546102b890600160a01b900460ff1681565b60405161012c9190610b80565b3480156102d157600080fd5b5061027f6102e0366004610ba8565b61073c565b3480156102f157600080fd5b50610190610300366004610bc1565b60076020526000908152604090205481565b6101b861089e565b34801561032657600080fd5b5061019060055481565b60008080806002600454600160a01b900460ff16600281111561035557610355610b6a565b141561037557336000818152600760205260409020549093509150610535565b6000546001600160a01b031633148061039857506004546001600160a01b031633145b156104a05750506006546005546008805460ff191660019081179091556004805460ff60a01b1916600160a01b908117918290556040516001600160a01b039095169550929391927f60a4a1bc10ae890f497872511943e85041b8c9f7f80b041024eb3b0b6b12937892610413929190910460ff1690610b80565b60405180910390a16104248261073c565b600354600654600254604051632142170760e11b81523060048201526001600160a01b03928316602482015260448101919091529116906342842e0e90606401600060405180830381600087803b15801561047e57600080fd5b505af1158015610492573d6000803e3d6000fd5b505050506001935050505090565b6006546001600160a01b031633141561051f576006546008546001600160a01b03909116935060ff16156104f0576006546001600160a01b03166000908152600760205260409020549150610535565b6005546006546001600160a01b03166000908152600760205260409020546105189190610bfb565b9150610535565b3360008181526007602052604090205490935091505b6000821161054257600080fd5b6001600160a01b0383166000908152600760205260408120805484929061056a908490610bfb565b90915550506040516001600160a01b0384169083156108fc029084906000818181858888f193505050501580156105a5573d6000803e3d6000fd5b506001935050505090565b6004546000906001600160a01b031633146105ca57600080fd5b6002600454600160a01b900460ff1660028111156105ea576105ea610b6a565b14156105f557600080fd5b6004805460ff60a01b1916600160a11b17908190556040517f60a4a1bc10ae890f497872511943e85041b8c9f7f80b041024eb3b0b6b1293789161064491600160a01b90910460ff1690610b80565b60405180910390a150600190565b6004546001600160a01b0316331461066957600080fd5b600380546001600160a01b0319166001600160a01b0384169081179091556002829055604051632142170760e11b8152336004820152306024820152604481018390526342842e0e90606401600060405180830381600087803b1580156106cf57600080fd5b505af11580156106e3573d6000803e3d6000fd5b50506004805460ff60a01b1916908190556040517f60a4a1bc10ae890f497872511943e85041b8c9f7f80b041024eb3b0b6b12937893506107309250600160a01b90910460ff1690610b80565b60405180910390a15050565b6004546001600160a01b0316331461075357600080fd5b61075b6109f5565b156108605760035460025460055460405163152a902d60e11b81526004810192909252602482015260009182916001600160a01b0390911690632a55205a906044016040805180830381865afa1580156107b9573d6000803e3d6000fd5b505050506040513d601f19601f820116820180604052508101906107dd9190610c12565b60405191935091506001600160a01b0383169082156108fc029083906000818181858888f19350505050158015610818573d6000803e3d6000fd5b506000546001600160a01b03166108fc6108328386610bfb565b6040518115909202916000818181858888f1935050505015801561085a573d6000803e3d6000fd5b50505050565b600080546040516001600160a01b039091169183156108fc02918491818181858888f19350505050158015610899573d6000803e3d6000fd5b505b50565b60006002600454600160a01b900460ff1660028111156108c0576108c0610b6a565b14156108cb57600080fd5b600034116108d857600080fd5b336000908152600760205260408120546108f3903490610c40565b9050600554811161090357600080fd5b6006546001600160a01b031660009081526007602052604080822054338352912082905580821161094d576109456001548361093f9190610c40565b82610a73565b600555610990565b6006546001600160a01b0316331461098d57600680546001600160a01b031916331790556001546109899083906109849084610c40565b610a73565b6005555b50805b60065460055460408051338152602081018690526001600160a01b03909316908301526060820183905260808201527f5c2b30b69878d1af2170dc75703de7e57d884d9a187d4aad26b10701f3236d1d9060a00160405180910390a160019250505090565b6003546040516301ffc9a760e01b815263152a902d60e11b600482015260009182916001600160a01b03909116906301ffc9a790602401602060405180830381865afa158015610a49573d6000803e3d6000fd5b505050506040513d601f19601f82011682018060405250810190610a6d9190610c58565b92915050565b600081831015610a84575081610a6d565b50919050565b6001600160a01b038116811461089b57600080fd5b600080600080600060808688031215610ab757600080fd5b8535610ac281610a8a565b94506020860135610ad281610a8a565b935060408601359250606086013567ffffffffffffffff80821115610af657600080fd5b818801915088601f830112610b0a57600080fd5b813581811115610b1957600080fd5b896020828501011115610b2b57600080fd5b9699959850939650602001949392505050565b60008060408385031215610b5157600080fd5b8235610b5c81610a8a565b946020939093013593505050565b634e487b7160e01b600052602160045260246000fd5b6020810160038310610ba257634e487b7160e01b600052602160045260246000fd5b91905290565b600060208284031215610bba57600080fd5b5035919050565b600060208284031215610bd357600080fd5b8135610bde81610a8a565b9392505050565b634e487b7160e01b600052601160045260246000fd5b600082821015610c0d57610c0d610be5565b500390565b60008060408385031215610c2557600080fd5b8251610c3081610a8a565b6020939093015192949293505050565b60008219821115610c5357610c53610be5565b500190565b600060208284031215610c6a57600080fd5b81518015158114610bde57600080fdfea264697066735822122036aa73fe0840b2defeaf1cfba6cdbd1c05b51b9a48fb1becda0b8a5b954dae2764736f6c634300080b0033";
        public AuctionDeploymentBase() : base(BYTECODE) { }
        public AuctionDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint256", "_bidIncrement", 1)]
        public virtual BigInteger BidIncrement { get; set; }
        [Parameter("address", "_payTo", 2)]
        public virtual string PayTo { get; set; }
        [Parameter("address", "_operator", 3)]
        public virtual string Operator { get; set; }
    }

    public partial class BidIncrementFunction : BidIncrementFunctionBase { }

    [Function("bidIncrement", "uint256")]
    public class BidIncrementFunctionBase : FunctionMessage
    {

    }

    public partial class CancelAuctionFunction : CancelAuctionFunctionBase { }

    [Function("cancelAuction", "bool")]
    public class CancelAuctionFunctionBase : FunctionMessage
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

    public partial class FundsByBidderFunction : FundsByBidderFunctionBase { }

    [Function("fundsByBidder", "uint256")]
    public class FundsByBidderFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetHighestBidFunction : GetHighestBidFunctionBase { }

    [Function("getHighestBid", "uint256")]
    public class GetHighestBidFunctionBase : FunctionMessage
    {

    }

    public partial class HighestBidderFunction : HighestBidderFunctionBase { }

    [Function("highestBidder", "address")]
    public class HighestBidderFunctionBase : FunctionMessage
    {

    }

    public partial class HighestBindingBidFunction : HighestBindingBidFunctionBase { }

    [Function("highestBindingBid", "uint256")]
    public class HighestBindingBidFunctionBase : FunctionMessage
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
        [Parameter("uint256", "_tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class OperatorFunction : OperatorFunctionBase { }

    [Function("operator", "address")]
    public class OperatorFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerHasWithdrawnFunction : OwnerHasWithdrawnFunctionBase { }

    [Function("ownerHasWithdrawn", "bool")]
    public class OwnerHasWithdrawnFunctionBase : FunctionMessage
    {

    }

    public partial class PayoutToSellerFunction : PayoutToSellerFunctionBase { }

    [Function("payoutToSeller")]
    public class PayoutToSellerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "withdrawalAmount", 1)]
        public virtual BigInteger WithdrawalAmount { get; set; }
    }

    public partial class PlaceBidFunction : PlaceBidFunctionBase { }

    [Function("placeBid", "bool")]
    public class PlaceBidFunctionBase : FunctionMessage
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

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw", "bool")]
    public class WithdrawFunctionBase : FunctionMessage
    {

    }

    public partial class LogBidEventDTO : LogBidEventDTOBase { }

    [Event("logBid")]
    public class LogBidEventDTOBase : IEventDTO
    {
        [Parameter("address", "bidder", 1, false )]
        public virtual string Bidder { get; set; }
        [Parameter("uint256", "bid", 2, false )]
        public virtual BigInteger Bid { get; set; }
        [Parameter("address", "highestBidder", 3, false )]
        public virtual string HighestBidder { get; set; }
        [Parameter("uint256", "highestBid", 4, false )]
        public virtual BigInteger HighestBid { get; set; }
        [Parameter("uint256", "highestBindingBid", 5, false )]
        public virtual BigInteger HighestBindingBid { get; set; }
    }

    public partial class StateChangedEventDTO : StateChangedEventDTOBase { }

    [Event("stateChanged")]
    public class StateChangedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "state", 1, false )]
        public virtual byte State { get; set; }
    }

    public partial class BidIncrementOutputDTO : BidIncrementOutputDTOBase { }

    [FunctionOutput]
    public class BidIncrementOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class FundsByBidderOutputDTO : FundsByBidderOutputDTOBase { }

    [FunctionOutput]
    public class FundsByBidderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetHighestBidOutputDTO : GetHighestBidOutputDTOBase { }

    [FunctionOutput]
    public class GetHighestBidOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class HighestBidderOutputDTO : HighestBidderOutputDTOBase { }

    [FunctionOutput]
    public class HighestBidderOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class HighestBindingBidOutputDTO : HighestBindingBidOutputDTOBase { }

    [FunctionOutput]
    public class HighestBindingBidOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class OperatorOutputDTO : OperatorOutputDTOBase { }

    [FunctionOutput]
    public class OperatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerHasWithdrawnOutputDTO : OwnerHasWithdrawnOutputDTOBase { }

    [FunctionOutput]
    public class OwnerHasWithdrawnOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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
