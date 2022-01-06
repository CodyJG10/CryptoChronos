namespace CryptoChronos.Shared.Models
{
    public class Watch
    {
        public string Serial { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public IEnumerable<Metadata> Metadata { get; set; }
        public string ImageCID { get; set; }
    }
}