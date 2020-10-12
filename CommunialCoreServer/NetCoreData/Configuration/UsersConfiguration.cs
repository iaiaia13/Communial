using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCoreData.Models;

namespace NetCoreData.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(t => t.ID);

            builder.HasIndex(t => t.UserName)
                .IsUnique();

            builder.Property(t => t.UserName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Password)
                .HasMaxLength(255);

            builder.Property(t => t.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(t => t.Name)
                .HasMaxLength(45);

            builder.Property(t => t.Phone)
             .HasMaxLength(45);
        }
    }
}