using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class ProdutoMapConfig : IEntityTypeConfiguration<ProdutoDTO>
    {
        public void Configure(EntityTypeBuilder<ProdutoDTO> builder)
        {
            builder.ToTable("PRODUTOS");

            builder.Property(p => p.Nome).IsRequired().HasMaxLength(60);

            builder.Property(p => p.Valor).IsRequired();

            builder.HasOne(p => p.Restaurante).WithMany(c => c.Produtos).HasForeignKey(c => c.RestauranteID);
        }
    }
}