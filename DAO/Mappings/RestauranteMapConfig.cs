using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class RestauranteMapConfig : IEntityTypeConfiguration<Restaurante>
    {
        public void Configure(EntityTypeBuilder<Restaurante> builder)
        {
            builder.Property(r => r.NomeFantasia).IsRequired().HasMaxLength(60);

            builder.Property(r => r.CNPJ).IsRequired().HasMaxLength(18);
            builder.HasIndex(r => r.CNPJ).IsUnique(true);

            builder.Property(r => r.Telefone).IsRequired();

            builder.Property(c => c.Endereco).IsRequired().HasMaxLength(60);

            builder.Property(r => r.Categoria).IsRequired();

            builder.HasIndex(p => p.Produtos);
        }
    }
}