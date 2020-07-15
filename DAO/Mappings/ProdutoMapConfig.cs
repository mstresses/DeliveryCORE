using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class ProdutoMapConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);

            builder.Property(p => p.Valor).IsRequired();

            builder.HasOne(p => p.Restaurante).WithMany(c => c.Produtos).HasForeignKey(c => c.RestauranteID);
        }
    }
}