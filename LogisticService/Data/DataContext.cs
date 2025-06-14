using LogisticService.Modules;
using LogisticService.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using LogisticService.Helpers;
using LogisticService.Users;

namespace LogisticService.Data
{
    internal class DataContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarBodyType> CarBodyTypes { get; set; }
        public DbSet<CarCondition> CarConditions { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<Transit> Transits { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelConfiguration());
            modelBuilder.ApplyConfiguration(new CarBodyTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarConditionConfiguration());
            modelBuilder.ApplyConfiguration(new ContainerConfiguration());
            modelBuilder.ApplyConfiguration(new DirectionConfiguration());
            modelBuilder.ApplyConfiguration(new InsuranceConfiguration());
            modelBuilder.ApplyConfiguration(new TransitConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.CONNECTION_STRING);
        }
    }
}
