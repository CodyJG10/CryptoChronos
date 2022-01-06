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

namespace Watches.Contracts.WatchNFT.ContractDefinition
{


    public partial class WatchNFTDeployment : WatchNFTDeploymentBase
    {
        public WatchNFTDeployment() : base(BYTECODE) { }
        public WatchNFTDeployment(string byteCode) : base(byteCode) { }
    }

    public class WatchNFTDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b5060408051808201825260078152665761746368657360c81b60208083019182528351808501909452600384526254494b60e81b9084015281519192916200005c91600091620000eb565b50805162000072906001906020840190620000eb565b5050506200008f620000896200009560201b60201c565b62000099565b620001ce565b3390565b600b80546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b828054620000f99062000191565b90600052602060002090601f0160209004810192826200011d576000855562000168565b82601f106200013857805160ff191683800117855562000168565b8280016001018555821562000168579182015b82811115620001685782518255916020019190600101906200014b565b50620001769291506200017a565b5090565b5b808211156200017657600081556001016200017b565b600181811c90821680620001a657607f821691505b60208210811415620001c857634e487b7160e01b600052602260045260246000fd5b50919050565b61206780620001de6000396000f3fe608060405234801561001057600080fd5b506004361061014d5760003560e01c80636352211e116100c3578063a22cb4651161007c578063a22cb465146102cc578063b88d4fde146102df578063c87b56dd146102f2578063d5bb3e7314610305578063e985e9c514610318578063f2fde38b1461035457600080fd5b80636352211e1461027257806370a0823114610285578063715018a61461029857806378a2d8a9146102a05780638da5cb5b146102b357806395d89b41146102c457600080fd5b806318160ddd1161011557806318160ddd146101e257806323b872dd146101f45780632a55205a146102075780632f745c591461023957806342842e0e1461024c5780634f6ccce71461025f57600080fd5b806301ffc9a71461015257806306fdde031461017a578063081812fc1461018f578063095ea7b3146101ba578063162094c4146101cf575b600080fd5b6101656101603660046119c0565b610367565b60405190151581526020015b60405180910390f35b610182610378565b6040516101719190611a35565b6101a261019d366004611a48565b61040a565b6040516001600160a01b039091168152602001610171565b6101cd6101c8366004611a7d565b610497565b005b6101cd6101dd366004611b53565b6105ad565b6009545b604051908152602001610171565b6101cd610202366004611b90565b6105e5565b61021a610215366004611bcc565b610616565b604080516001600160a01b039093168352602083019190915201610171565b6101e6610247366004611a7d565b610674565b6101cd61025a366004611b90565b61070a565b6101e661026d366004611a48565b610725565b6101a2610280366004611a48565b6107b8565b6101e6610293366004611bee565b61082f565b6101cd6108b6565b6101cd6102ae366004611c09565b6108ec565b600b546001600160a01b03166101a2565b610182610931565b6101cd6102da366004611c4f565b610940565b6101cd6102ed366004611c8b565b61094b565b610182610300366004611a48565b61097d565b6101cd610313366004611d07565b610988565b610165610326366004611d79565b6001600160a01b03918216600090815260056020908152604080832093909416825291909152205460ff1690565b6101cd610362366004611bee565b6109d8565b600061037282610a73565b92915050565b60606000805461038790611dac565b80601f01602080910402602001604051908101604052809291908181526020018280546103b390611dac565b80156104005780601f106103d557610100808354040283529160200191610400565b820191906000526020600020905b8154815290600101906020018083116103e357829003601f168201915b5050505050905090565b600061041582610a98565b61047b5760405162461bcd60e51b815260206004820152602c60248201527f4552433732313a20617070726f76656420717565727920666f72206e6f6e657860448201526b34b9ba32b73a103a37b5b2b760a11b60648201526084015b60405180910390fd5b506000908152600460205260409020546001600160a01b031690565b60006104a2826107b8565b9050806001600160a01b0316836001600160a01b031614156105105760405162461bcd60e51b815260206004820152602160248201527f4552433732313a20617070726f76616c20746f2063757272656e74206f776e656044820152603960f91b6064820152608401610472565b336001600160a01b038216148061052c575061052c8133610326565b61059e5760405162461bcd60e51b815260206004820152603860248201527f4552433732313a20617070726f76652063616c6c6572206973206e6f74206f7760448201527f6e6572206e6f7220617070726f76656420666f7220616c6c00000000000000006064820152608401610472565b6105a88383610ab5565b505050565b600b546001600160a01b031633146105d75760405162461bcd60e51b815260040161047290611de7565b6105e18282610b23565b5050565b6105ef3382610bae565b61060b5760405162461bcd60e51b815260040161047290611e1c565b6105a8838383610c98565b6000828152600c602090815260408083208151808301909252546001600160a01b038116808352600160a01b90910462ffffff169282018390529291612710906106609086611e83565b61066a9190611eb8565b9150509250929050565b600061067f8361082f565b82106106e15760405162461bcd60e51b815260206004820152602b60248201527f455243373231456e756d657261626c653a206f776e657220696e646578206f7560448201526a74206f6620626f756e647360a81b6064820152608401610472565b506001600160a01b03919091166000908152600760209081526040808320938352929052205490565b6105a88383836040518060200160405280600081525061094b565b600061073060095490565b82106107935760405162461bcd60e51b815260206004820152602c60248201527f455243373231456e756d657261626c653a20676c6f62616c20696e646578206f60448201526b7574206f6620626f756e647360a01b6064820152608401610472565b600982815481106107a6576107a6611ecc565b90600052602060002001549050919050565b6000818152600260205260408120546001600160a01b0316806103725760405162461bcd60e51b815260206004820152602960248201527f4552433732313a206f776e657220717565727920666f72206e6f6e657869737460448201526832b73a103a37b5b2b760b91b6064820152608401610472565b60006001600160a01b03821661089a5760405162461bcd60e51b815260206004820152602a60248201527f4552433732313a2062616c616e636520717565727920666f7220746865207a65604482015269726f206164647265737360b01b6064820152608401610472565b506001600160a01b031660009081526003602052604090205490565b600b546001600160a01b031633146108e05760405162461bcd60e51b815260040161047290611de7565b6108ea6000610e43565b565b600b546001600160a01b031633146109165760405162461bcd60e51b815260040161047290611de7565b6109208484610e95565b61092b838284610eaf565b50505050565b60606001805461038790611dac565b6105e1338383610f58565b6109553383610bae565b6109715760405162461bcd60e51b815260040161047290611e1c565b61092b84848484611027565b60606103728261105a565b600b546001600160a01b031633146109b25760405162461bcd60e51b815260040161047290611de7565b6109bc8585610e95565b6109c68484610b23565b6109d1848284610eaf565b5050505050565b600b546001600160a01b03163314610a025760405162461bcd60e51b815260040161047290611de7565b6001600160a01b038116610a675760405162461bcd60e51b815260206004820152602660248201527f4f776e61626c653a206e6577206f776e657220697320746865207a65726f206160448201526564647265737360d01b6064820152608401610472565b610a7081610e43565b50565b60006001600160e01b0319821663152a902d60e11b14806103725750610372826111e6565b6000908152600260205260409020546001600160a01b0316151590565b600081815260046020526040902080546001600160a01b0319166001600160a01b0384169081179091558190610aea826107b8565b6001600160a01b03167f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92560405160405180910390a45050565b610b2c82610a98565b610b8f5760405162461bcd60e51b815260206004820152602e60248201527f45524337323155524953746f726167653a2055524920736574206f66206e6f6e60448201526d32bc34b9ba32b73a103a37b5b2b760911b6064820152608401610472565b600082815260066020908152604090912082516105a892840190611911565b6000610bb982610a98565b610c1a5760405162461bcd60e51b815260206004820152602c60248201527f4552433732313a206f70657261746f7220717565727920666f72206e6f6e657860448201526b34b9ba32b73a103a37b5b2b760a11b6064820152608401610472565b6000610c25836107b8565b9050806001600160a01b0316846001600160a01b03161480610c605750836001600160a01b0316610c558461040a565b6001600160a01b0316145b80610c9057506001600160a01b0380821660009081526005602090815260408083209388168352929052205460ff165b949350505050565b826001600160a01b0316610cab826107b8565b6001600160a01b031614610d135760405162461bcd60e51b815260206004820152602960248201527f4552433732313a207472616e73666572206f6620746f6b656e2074686174206960448201526839903737ba1037bbb760b91b6064820152608401610472565b6001600160a01b038216610d755760405162461bcd60e51b8152602060048201526024808201527f4552433732313a207472616e7366657220746f20746865207a65726f206164646044820152637265737360e01b6064820152608401610472565b610d8083838361120b565b610d8b600082610ab5565b6001600160a01b0383166000908152600360205260408120805460019290610db4908490611ee2565b90915550506001600160a01b0382166000908152600360205260408120805460019290610de2908490611ef9565b909155505060008181526002602052604080822080546001600160a01b0319166001600160a01b0386811691821790925591518493918716917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef91a4505050565b600b80546001600160a01b038381166001600160a01b0319831681179093556040519116919082907f8be0079c531659141344cd1fd0a4f28419497f9722a3daafe3b4186f6b6457e090600090a35050565b6105e1828260405180602001604052806000815250611216565b612710811115610f015760405162461bcd60e51b815260206004820152601a60248201527f45524332393831526f79616c746965733a20546f6f20686967680000000000006044820152606401610472565b6040805180820182526001600160a01b03938416815262ffffff92831660208083019182526000968752600c905291909420935184549151909216600160a01b026001600160b81b03199091169190921617179055565b816001600160a01b0316836001600160a01b03161415610fba5760405162461bcd60e51b815260206004820152601960248201527f4552433732313a20617070726f766520746f2063616c6c6572000000000000006044820152606401610472565b6001600160a01b03838116600081815260056020908152604080832094871680845294825291829020805460ff191686151590811790915591519182527f17307eab39ab6107e8899845ad3d59bd9653f200f220920489ca2b5937696c31910160405180910390a3505050565b611032848484610c98565b61103e84848484611249565b61092b5760405162461bcd60e51b815260040161047290611f11565b606061106582610a98565b6110cb5760405162461bcd60e51b815260206004820152603160248201527f45524337323155524953746f726167653a2055524920717565727920666f72206044820152703737b732bc34b9ba32b73a103a37b5b2b760791b6064820152608401610472565b600082815260066020526040812080546110e490611dac565b80601f016020809104026020016040519081016040528092919081815260200182805461111090611dac565b801561115d5780601f106111325761010080835404028352916020019161115d565b820191906000526020600020905b81548152906001019060200180831161114057829003601f168201915b50505050509050600061119860408051808201909152601581527468747470733a2f2f697066732e696f2f697066732f60581b602082015290565b90508051600014156111ab575092915050565b8151156111dd5780826040516020016111c5929190611f63565b60405160208183030381529060405292505050919050565b610c9084611347565b60006001600160e01b0319821663780e9d6360e01b148061037257506103728261143c565b6105a883838361148c565b6112208383611544565b61122d6000848484611249565b6105a85760405162461bcd60e51b815260040161047290611f11565b60006001600160a01b0384163b1561133c57604051630a85bd0160e11b81526001600160a01b0385169063150b7a029061128d903390899088908890600401611f92565b6020604051808303816000875af19250505080156112c8575060408051601f3d908101601f191682019092526112c591810190611fcf565b60015b611322573d8080156112f6576040519150601f19603f3d011682016040523d82523d6000602084013e6112fb565b606091505b50805161131a5760405162461bcd60e51b815260040161047290611f11565b805181602001fd5b6001600160e01b031916630a85bd0160e11b149050610c90565b506001949350505050565b606061135282610a98565b6113b65760405162461bcd60e51b815260206004820152602f60248201527f4552433732314d657461646174613a2055524920717565727920666f72206e6f60448201526e3732bc34b9ba32b73a103a37b5b2b760891b6064820152608401610472565b60006113ea60408051808201909152601581527468747470733a2f2f697066732e696f2f697066732f60581b602082015290565b9050600081511161140a5760405180602001604052806000815250611435565b8061141484611683565b604051602001611425929190611f63565b6040516020818303038152906040525b9392505050565b60006001600160e01b031982166380ac58cd60e01b148061146d57506001600160e01b03198216635b5e139f60e01b145b8061037257506301ffc9a760e01b6001600160e01b0319831614610372565b6001600160a01b0383166114e7576114e281600980546000838152600a60205260408120829055600182018355919091527f6e1540171b6c0c960b71a7020d9f60077f6af931a8bbf590da0223dacf75c7af0155565b61150a565b816001600160a01b0316836001600160a01b03161461150a5761150a8382611781565b6001600160a01b038216611521576105a88161181e565b826001600160a01b0316826001600160a01b0316146105a8576105a882826118cd565b6001600160a01b03821661159a5760405162461bcd60e51b815260206004820181905260248201527f4552433732313a206d696e7420746f20746865207a65726f20616464726573736044820152606401610472565b6115a381610a98565b156115f05760405162461bcd60e51b815260206004820152601c60248201527f4552433732313a20746f6b656e20616c7265616479206d696e746564000000006044820152606401610472565b6115fc6000838361120b565b6001600160a01b0382166000908152600360205260408120805460019290611625908490611ef9565b909155505060008181526002602052604080822080546001600160a01b0319166001600160a01b03861690811790915590518392907fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef908290a45050565b6060816116a75750506040805180820190915260018152600360fc1b602082015290565b8160005b81156116d157806116bb81611fec565b91506116ca9050600a83611eb8565b91506116ab565b60008167ffffffffffffffff8111156116ec576116ec611aa7565b6040519080825280601f01601f191660200182016040528015611716576020820181803683370190505b5090505b8415610c905761172b600183611ee2565b9150611738600a86612007565b611743906030611ef9565b60f81b81838151811061175857611758611ecc565b60200101906001600160f81b031916908160001a90535061177a600a86611eb8565b945061171a565b6000600161178e8461082f565b6117989190611ee2565b6000838152600860205260409020549091508082146117eb576001600160a01b03841660009081526007602090815260408083208584528252808320548484528184208190558352600890915290208190555b5060009182526008602090815260408084208490556001600160a01b039094168352600781528383209183525290812055565b60095460009061183090600190611ee2565b6000838152600a60205260408120546009805493945090928490811061185857611858611ecc565b90600052602060002001549050806009838154811061187957611879611ecc565b6000918252602080832090910192909255828152600a909152604080822084905585825281205560098054806118b1576118b161201b565b6001900381819060005260206000200160009055905550505050565b60006118d88361082f565b6001600160a01b039093166000908152600760209081526040808320868452825280832085905593825260089052919091209190915550565b82805461191d90611dac565b90600052602060002090601f01602090048101928261193f5760008555611985565b82601f1061195857805160ff1916838001178555611985565b82800160010185558215611985579182015b8281111561198557825182559160200191906001019061196a565b50611991929150611995565b5090565b5b808211156119915760008155600101611996565b6001600160e01b031981168114610a7057600080fd5b6000602082840312156119d257600080fd5b8135611435816119aa565b60005b838110156119f85781810151838201526020016119e0565b8381111561092b5750506000910152565b60008151808452611a218160208601602086016119dd565b601f01601f19169290920160200192915050565b6020815260006114356020830184611a09565b600060208284031215611a5a57600080fd5b5035919050565b80356001600160a01b0381168114611a7857600080fd5b919050565b60008060408385031215611a9057600080fd5b611a9983611a61565b946020939093013593505050565b634e487b7160e01b600052604160045260246000fd5b600067ffffffffffffffff80841115611ad857611ad8611aa7565b604051601f8501601f19908116603f01168101908282118183101715611b0057611b00611aa7565b81604052809350858152868686011115611b1957600080fd5b858560208301376000602087830101525050509392505050565b600082601f830112611b4457600080fd5b61143583833560208501611abd565b60008060408385031215611b6657600080fd5b82359150602083013567ffffffffffffffff811115611b8457600080fd5b61066a85828601611b33565b600080600060608486031215611ba557600080fd5b611bae84611a61565b9250611bbc60208501611a61565b9150604084013590509250925092565b60008060408385031215611bdf57600080fd5b50508035926020909101359150565b600060208284031215611c0057600080fd5b61143582611a61565b60008060008060808587031215611c1f57600080fd5b611c2885611a61565b93506020850135925060408501359150611c4460608601611a61565b905092959194509250565b60008060408385031215611c6257600080fd5b611c6b83611a61565b915060208301358015158114611c8057600080fd5b809150509250929050565b60008060008060808587031215611ca157600080fd5b611caa85611a61565b9350611cb860208601611a61565b925060408501359150606085013567ffffffffffffffff811115611cdb57600080fd5b8501601f81018713611cec57600080fd5b611cfb87823560208401611abd565b91505092959194509250565b600080600080600060a08688031215611d1f57600080fd5b611d2886611a61565b945060208601359350604086013567ffffffffffffffff811115611d4b57600080fd5b611d5788828901611b33565b93505060608601359150611d6d60808701611a61565b90509295509295909350565b60008060408385031215611d8c57600080fd5b611d9583611a61565b9150611da360208401611a61565b90509250929050565b600181811c90821680611dc057607f821691505b60208210811415611de157634e487b7160e01b600052602260045260246000fd5b50919050565b6020808252818101527f4f776e61626c653a2063616c6c6572206973206e6f7420746865206f776e6572604082015260600190565b60208082526031908201527f4552433732313a207472616e736665722063616c6c6572206973206e6f74206f6040820152701ddb995c881b9bdc88185c1c1c9bdd9959607a1b606082015260800190565b634e487b7160e01b600052601160045260246000fd5b6000816000190483118215151615611e9d57611e9d611e6d565b500290565b634e487b7160e01b600052601260045260246000fd5b600082611ec757611ec7611ea2565b500490565b634e487b7160e01b600052603260045260246000fd5b600082821015611ef457611ef4611e6d565b500390565b60008219821115611f0c57611f0c611e6d565b500190565b60208082526032908201527f4552433732313a207472616e7366657220746f206e6f6e20455243373231526560408201527131b2b4bb32b91034b6b83632b6b2b73a32b960711b606082015260800190565b60008351611f758184602088016119dd565b835190830190611f898183602088016119dd565b01949350505050565b6001600160a01b0385811682528416602082015260408101839052608060608201819052600090611fc590830184611a09565b9695505050505050565b600060208284031215611fe157600080fd5b8151611435816119aa565b600060001982141561200057612000611e6d565b5060010190565b60008261201657612016611ea2565b500690565b634e487b7160e01b600052603160045260246000fdfea26469706673582212202a22b9d4035134806cd5c1b5cf53fb8361bebae9641fbbec999dabfe2582578464736f6c634300080b0033";
        public WatchNFTDeploymentBase() : base(BYTECODE) { }
        public WatchNFTDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class RoyaltyInfoFunction : RoyaltyInfoFunctionBase { }

    [Function("royaltyInfo", typeof(RoyaltyInfoOutputDTO))]
    public class RoyaltyInfoFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class SafeMintFunction : SafeMintFunctionBase { }

    [Function("safeMint")]
    public class SafeMintFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "royaltyAmount", 3)]
        public virtual BigInteger RoyaltyAmount { get; set; }
        [Parameter("address", "royaltyRecipient", 4)]
        public virtual string RoyaltyRecipient { get; set; }
    }

    public partial class SafeMintAndSetUriFunction : SafeMintAndSetUriFunctionBase { }

    [Function("safeMintAndSetUri")]
    public class SafeMintAndSetUriFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string", "uri", 3)]
        public virtual string Uri { get; set; }
        [Parameter("uint256", "royaltyAmount", 4)]
        public virtual BigInteger RoyaltyAmount { get; set; }
        [Parameter("address", "royaltyRecipient", 5)]
        public virtual string RoyaltyRecipient { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "_data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetTokenURIFunction : SetTokenURIFunctionBase { }

    [Function("setTokenURI")]
    public class SetTokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string", "_tokenURI", 2)]
        public virtual string TokenURI { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenByIndexFunction : TokenByIndexFunctionBase { }

    [Function("tokenByIndex", "uint256")]
    public class TokenByIndexFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class TokenOfOwnerByIndexFunction : TokenOfOwnerByIndexFunctionBase { }

    [Function("tokenOfOwnerByIndex", "uint256")]
    public class TokenOfOwnerByIndexFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class RoyaltyInfoOutputDTO : RoyaltyInfoOutputDTOBase { }

    [FunctionOutput]
    public class RoyaltyInfoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "receiver", 1)]
        public virtual string Receiver { get; set; }
        [Parameter("uint256", "royaltyAmount", 2)]
        public virtual BigInteger RoyaltyAmount { get; set; }
    }













    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenByIndexOutputDTO : TokenByIndexOutputDTOBase { }

    [FunctionOutput]
    public class TokenByIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenOfOwnerByIndexOutputDTO : TokenOfOwnerByIndexOutputDTOBase { }

    [FunctionOutput]
    public class TokenOfOwnerByIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }




}