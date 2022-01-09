using CryptoChronos.Shared.Identity;
using CryptoChronos.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoChronos.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<AuctionMetadata> AuctionMetadata { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoleClaims> UserRoleClaims { get; set; }
        public DbSet<LocalWatchRecord> LocalWatchRecords { get; set; }
        public DbSet<LocalListingRecord> LocalListingRecords { get; set; }  

        public ApplicationDbContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(x => x.RoleClaims)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
