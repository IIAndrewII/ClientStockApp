using ClientStockApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientStockApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<StockMarketData> StockMarketData { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();
        }
    }
}
