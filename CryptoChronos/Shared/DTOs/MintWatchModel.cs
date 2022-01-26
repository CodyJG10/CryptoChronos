using CryptoChronos.Shared.Models;

namespace CryptoChronos.Shared.DTOs
{
    public class MintWatchModel
    {
        public byte[] FileData { get; set; }
        public string UserAddress { get; set; }
        public Watch Watch { get; set; }
        public string RoyaltyRecipient { get; set; }
        public string RoyaltyAmount { get; set; }
    }
}