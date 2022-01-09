namespace CryptoChronos.Shared.DTOs
{
    public class CreateAuctionModel : CreateSaleModelBase
    {
        public string BidIncrement { get; set; }
        public string OperatorAddress { get; set; }
    }
}
