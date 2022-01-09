namespace CryptoChronos.Shared.DTOs
{
    public class CreateListingModel : CreateSaleModelBase
    {
        public string Price { get; set; }
        public string OwnerAddress { get; set; }
    }
}