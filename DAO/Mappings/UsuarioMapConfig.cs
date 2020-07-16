using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class UsuarioMapConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(u => u.Login).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Senha).IsRequired().HasMaxLength(64);
        }
    }
}