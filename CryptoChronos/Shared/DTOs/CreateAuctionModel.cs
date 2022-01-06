namespace CryptoChronos.Shared.DTOs
{
    public class CreateAuctionModel
    {
        public string BidIncrement { get; set; }
        public string TokenId { get; set; }
        public string PayTo { get; set; }
        public string OperatorAddress { get; set; }
    }
}
