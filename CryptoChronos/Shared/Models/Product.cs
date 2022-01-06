using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.Models
{
    public abstract class Product
    {
        public string Address { get; set; }
        public string SellerAddress { get; set; }
        public string TokenId { get; set; }
    }
}
