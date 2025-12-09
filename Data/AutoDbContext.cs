using Microsoft.EntityFrameworkCore;

namespace AutodjaOmanikud
{
    public class AutoDbContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=AutoDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>().ToTable("Owners");
            modelBuilder.Entity<Car>().ToTable("Cars");
            modelBuilder.Entity<Service>().ToTable("Services");
            modelBuilder.Entity<ServiceType>().ToTable("ServiceTypes");

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars)
                .HasForeignKey(c => c.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.ServiceType)
                .WithMany()
                .HasForeignKey(s => s.ServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
