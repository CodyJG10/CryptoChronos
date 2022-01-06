namespace CryptoChronos.Shared.Identity
{
    public class UserRoleClaims
    {
        public int Id { get; set; }
        //[ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
