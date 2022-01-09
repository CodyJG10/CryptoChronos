using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.Models
{
    public class LocalWatchRecord
    {
        public int Id { get; set; } 
        public string Serial { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string NftId { get; set; }
        public string ImageCID { get; set; }
    }
}