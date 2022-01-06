namespace CryptoChronos.Shared.Identity
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public virtual ICollection<UserRoleClaims>? RoleClaims { get; set; }
        public string? ProfilePictureUri { get; set; }

    }
}