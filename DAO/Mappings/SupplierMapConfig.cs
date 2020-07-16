using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class SupplierMapConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(r => r.CompanyName).IsRequired().HasMaxLength(60);

            builder.Property(r => r.Cnpj).IsRequired().HasMaxLength(18);
            builder.HasIndex(r => r.Cnpj).IsUnique(true);

            builder.Property(s => s.TradingName).IsRequired().HasMaxLength(120);

            builder.OwnsOne(s => s.Address, address =>
            {
                address.Property(s => s.State).IsRequired().HasMaxLength(2);
                address.Property(s => s.Country).IsRequired().HasMaxLength(100);
                address.Property(s => s.Number).IsRequired().HasMaxLength(10);
                address.Property(s => s.Street).IsRequired().HasMaxLength(100);
                address.Property(s => s.City).IsRequired().HasMaxLength(100);
            });

            builder.Property(r => r.Telephone).IsRequired();

            builder.Property(s => s.Email).IsRequired().HasMaxLength(100);

            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        }
    }
}