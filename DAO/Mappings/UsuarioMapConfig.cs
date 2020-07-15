using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    internal class UsuarioMapConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Email).HasMaxLength(100);
            builder.HasIndex(u => u.Email).IsUnique(true).HasName("UQ_USUARIO_EMAIL");

            builder.Property(u => u.Senha).HasMaxLength(15);

            builder.Property(u => u.Role).IsRequired();
        }
    }
}