using CryptoChronos.Server.Data;
using CryptoChronos.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace CryptoChronos.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ListingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Metadata/{address}")]
        public AuctionMetadata GetAuctionMetadata(string address)
            => _context.AuctionMetadata.SingleOrDefault(x => x.AuctionAddress.ToLower() == address.ToLower());

        [HttpPost("Metadata")]
        public async Task CreateAuctionMetadata(AuctionMetadata model)
        {
            _context.AuctionMetadata.Add(model);
            await _context.SaveChangesAsync();
        }

        [HttpPut("Metadata/{address}")]
        public async Task UpdateMetadataViews(string address)
        {
            var model = _context.AuctionMetadata.SingleOrDefault(x => x.AuctionAddress.ToLower() == address.ToLower());
            model.Views = model.Views + 1;
            _context.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}