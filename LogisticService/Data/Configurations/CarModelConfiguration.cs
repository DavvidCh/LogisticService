using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticService.Data.Configurations
{
    internal class CarModelConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(m => m.Id);
            
            builder.HasOne(m => m.CarBodyType)
                .WithMany(b => b.CarModels)
                .HasForeignKey(m => m.CarBodyTypeId);
        }
    }
}
