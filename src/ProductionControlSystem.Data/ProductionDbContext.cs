using Microsoft.EntityFrameworkCore;
using ProductionControlSystem.Core.Models;

namespace ProductionControlSystem.Data
    {
    public class ProductionDbContext : DbContext
        {
        public ProductionDbContext(DbContextOptions<ProductionDbContext> options)
            : base(options)
            {
            }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Shipment> Shipments => Set<Shipment>();
        public DbSet<Box> Boxes => Set<Box>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasIndex(c => c.ClientCode)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasIndex(p => p.ProjectCode)
                .IsUnique();
            }
        }
    }
