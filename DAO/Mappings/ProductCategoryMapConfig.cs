using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class ProductCategoryMapConfig : IEntityTypeConfiguration<CategoriaDeProduto>
    {
        public void Configure(EntityTypeBuilder<CategoriaDeProduto> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");

            builder.Property(s => s.IsDeleted).HasDefaultValue(false).HasColumnName("IsDeleted");

            builder.HasOne<Fornecedor>(p => p.Supplier)
                   .WithMany(s => s.ProductCategories).HasForeignKey(p => p.SupplierId);
        }
    }
}