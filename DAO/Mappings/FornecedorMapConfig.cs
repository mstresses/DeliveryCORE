using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAO.Mappings
{
    public class FornecedorMapConfig : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.Property(f => f.RazaoSocial).IsRequired().HasMaxLength(100);

            builder.Property(f => f.Cnpj).IsRequired().HasMaxLength(18);

            builder.Property(f => f.NomeFantasia).IsRequired().HasMaxLength(100);

            builder.OwnsOne(f => f.Endereco, endereco =>
            {
                endereco.Property(f => f.Numero).IsRequired();
                endereco.Property(f => f.Rua).IsRequired().HasMaxLength(100);
                endereco.Property(f => f.UF).IsRequired().HasMaxLength(2);
                endereco.Property(f => f.Pais).IsRequired().HasMaxLength(100);
                endereco.Property(f => f.Cidade).IsRequired().HasMaxLength(100);
            });

            builder.Property(f => f.TelefoneDeContato).IsRequired();

            builder.Property(f => f.EmailDeContato).IsRequired().HasMaxLength(100);
        }
    }
}