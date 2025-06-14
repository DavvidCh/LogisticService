using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticService.Data.Configurations
{
    internal class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.CarModels)
                .WithOne(m => m.Car)
                .HasForeignKey(m => m.CarId);
        }
    }
}
