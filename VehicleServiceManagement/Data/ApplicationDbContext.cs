using Microsoft.EntityFrameworkCore;
using VehicleServiceManagement.Models;

namespace VehicleServiceManagement.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options ):base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<ServiceRecord> ServiceRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ServiceRecord>()
                .Property(s => s.Cost)
                .HasPrecision(18, 2);
        }
    }
}
