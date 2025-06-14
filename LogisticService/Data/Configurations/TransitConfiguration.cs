using LogisticService.Modules;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LogisticService.Data.Configurations
{
    internal class TransitConfiguration : IEntityTypeConfiguration<Transit>
    {
        public void Configure(EntityTypeBuilder<Transit> builder)
        {
            builder.HasKey(t => t.Id);
        }
    }
}
