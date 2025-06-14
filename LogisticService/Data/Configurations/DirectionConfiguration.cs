using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using LogisticService.Modules;

namespace LogisticService.Data.Configurations
{
    internal class DirectionConfiguration : IEntityTypeConfiguration<Direction>
    {
        public void Configure(EntityTypeBuilder<Direction> builder)
        {
            builder.HasKey(c => c.Id);
        }
    }
}