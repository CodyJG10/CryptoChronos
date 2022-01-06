using CryptoChronos.Shared.Enums;

namespace CryptoChronos.Shared.Models
{
    public class EscrowContract
    {
        public string Seller { get; set; }
        public string ContractAddress { get; set; }
        public string? Buyer { get; set; }
        public string? TokenId { get; set; }
        public EscrowStatus State { get; set; }
        public string? Link { get; set; }
        public Watch? Watch { get; set; }
    }
}