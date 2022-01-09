using CryptoChronos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChronos.Shared.DTOs
{
    public class CreateSaleModelBase
    {
        public string PayTo { get; set; }
        public string TokenId { get; set; }
        public Watch Watch { get; set; }
        public string SellerAddress { get; set; }
    }
}
