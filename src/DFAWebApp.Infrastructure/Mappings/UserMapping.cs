using DFAWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DFAWebApp.Infrastructure.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.UserEmail)
                   .IsRequired()
                   .HasColumnType("varchar(150)");

            builder.Property(u => u.UserRole)
                   .IsRequired()
                   .HasColumnType("varchar(10)")
                   .HasDefaultValue("User");

            builder.ToTable("Users");
        }
    }
}
