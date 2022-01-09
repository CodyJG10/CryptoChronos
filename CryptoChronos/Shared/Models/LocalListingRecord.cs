using CryptoChronos.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.Models
{
    public class LocalListingRecord
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? SellerAddress { get; set; }
        public string? Description { get; set; }
        public string TokenId { get; set; }
        public string ImageCID { get; set; }
        public bool IsActive { get; set; }
        public string ListingAddress { get; set; }
        public ListingType ListingType { get; set; }
    }
}
