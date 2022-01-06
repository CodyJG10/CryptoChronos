using System.Numerics;

namespace CryptoChronos.Shared.Models
{
    public class Auction : Product
    {
        public string OperatorAddress { get; set; }
        public string BidIncrease { get; set; }
    }
}