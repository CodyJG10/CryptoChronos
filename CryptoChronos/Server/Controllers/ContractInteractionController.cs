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
        private IConfiguration _config;

        public ContractInteractionController(NftServerService nftService, ApplicationDbContext context, IConfiguration config)
        {
            _nftService = nftService;
            _context = context;
            _config = config;
        }
    }
}
