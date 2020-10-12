using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreData.Models;

namespace NetCoreData.Configurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.Name)
                .HasMaxLength(255);
        }
    }
}