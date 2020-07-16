using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class CategoriaDeProdutoMapConfig : IEntityTypeConfiguration<CategoriaDeProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaDeProduto> builder)
        {
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(100);

            builder.HasOne<Fornecedor>(c => c.Fornecedor).WithMany(c => c.CategoriaDeProduto).HasForeignKey(p => p.FornecedorId);
        }
    }
}