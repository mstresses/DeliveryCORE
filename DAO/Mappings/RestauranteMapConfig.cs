using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class RestauranteMapConfig : IEntityTypeConfiguration<ProdutoDTO>
    {
        public void Configure(EntityTypeBuilder<ProdutoDTO> builder)
        {
            builder.ToTable("RESTAURANTES");

            builder.Property(r => r.NomeFantasia).IsRequired().HasMaxLength(60);

            builder.Property(r => r.CNPJ).IsRequired().HasMaxLength(18);
            builder.HasIndex(r => r.CNPJ).IsUnique(true);

            builder.Property(r => r.Telefone).IsRequired();

            builder.Property(r => r.Categoria).IsRequired();
        }
    }
}