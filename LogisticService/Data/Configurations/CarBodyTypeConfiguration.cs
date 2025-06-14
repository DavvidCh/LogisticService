using LogisticService.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticService.Data.Configurations
{
    internal class CarBodyTypeConfiguration : IEntityTypeConfiguration<CarBodyType>
    {
        public void Configure(EntityTypeBuilder<CarBodyType> builder)
        {
            builder.HasKey(b => b.Id);
        }
    }
}
