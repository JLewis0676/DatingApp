using DatingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace DatingApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) { }

        public DbSet<AppUser> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(e => e.Photos)
                .WithOne(e => e.AppUser)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();
            modelBuilder.Entity<Photo>()
                .HasOne(e => e.AppUser)
                .WithMany(e => e.Photos)
                .HasForeignKey(e => e.AppUserId)
                .IsRequired();
        }
    }
}

