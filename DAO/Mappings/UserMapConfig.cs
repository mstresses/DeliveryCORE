using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class UserMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Password).IsRequired().HasMaxLength(64);

            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        }
    }
}