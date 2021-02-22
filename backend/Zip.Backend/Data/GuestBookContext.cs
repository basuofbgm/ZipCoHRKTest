using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Zip.Backend.Data
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Guest> GuestBook { get; set; }
       public DbSet<DogsRandomPictures> DogRandomPictures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(guest =>
            {
                guest.HasKey(i => i.Id);
                guest.Property(i => i.Created)
                    .IsConcurrencyToken()
                    .IsRequired();
            });
      modelBuilder.Entity<DogsRandomPictures>(_DogsRandomPictures =>
      {
        _DogsRandomPictures.HasKey(i => i.Id);
        _DogsRandomPictures.Property(i => i.Created)
            .IsConcurrencyToken()
            .IsRequired();
      });
    }        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSnakeCaseNamingConvention();
    }
}
