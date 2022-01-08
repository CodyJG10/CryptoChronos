using CryptoChronos.Server.Data;
using Microsoft.AspNetCore.Mvc;
using NFT.ContractInteraction.Server;

namespace WatchNFT.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ContractInteractionController : ControllerBase
    {
        private NftServerService _nftService;
        private ApplicationDbContext _context;

        public ContractInteractionController(NftServerService nftService, ApplicationDbContext context)
        {
            _nftService = nftService;
            _context = context;
        }
    }
}
