using Microsoft.AspNetCore.Mvc;
using NFT.ContractInteraction.Server;

namespace WatchNFT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ContractInteractionController : ControllerBase
    {
        private NftServerService _nftService;

        public ContractInteractionController(NftServerService nftService)
        {
            _nftService = nftService;
        }
    }
}
