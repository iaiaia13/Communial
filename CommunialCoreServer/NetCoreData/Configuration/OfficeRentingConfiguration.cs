using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreData.Models;

namespace NetCoreData.Configurations
{
    public class OfficeRentingConfiguration : IEntityTypeConfiguration<OfficeRenting>
    {
        public void Configure(EntityTypeBuilder<OfficeRenting> builder)
        {
            builder.HasKey(t => t.ID);

            builder.HasOne(t => t.Office)
                .WithMany(t => t.OfficeRenting)
                .HasForeignKey(t => t.OfficeID);
        }
    }
}