using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class ProductCategoryMapConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");

            builder.Property(s => s.IsDeleted).HasDefaultValue(false).HasColumnName("IsDeleted");

            builder.HasOne<Supplier>(p => p.Supplier)
                   .WithMany(s => s.ProductCategories).HasForeignKey(p => p.SupplierId);
        }
    }
}