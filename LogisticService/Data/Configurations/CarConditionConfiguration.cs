using LogisticService.Modules;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Data.Configurations
{
    internal class CarConditionConfiguration : IEntityTypeConfiguration<CarCondition>
    {
        public void Configure(EntityTypeBuilder<CarCondition> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}
