using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FishingPlace.Models;

namespace FishingPlace.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FishingPlace.Models.FishingVessel> FishingVessel { get; set; } = default!;
        public DbSet<FishingPlace.Models.Owner> Owner { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FishingVessel>()
                .HasOne(v => v.Fish)
                .WithOne(f => f.FishingVessel)
                .HasForeignKey<FishingVessel>(v => v.FishId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<FishingPlace.Models.Fish> Fish { get; set; } = default!;


    }
}
