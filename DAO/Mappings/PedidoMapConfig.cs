using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class PedidoMapConfig : IEntityTypeConfiguration<PedidoDTO>
    {
        public void Configure(EntityTypeBuilder<PedidoDTO> builder)
        {
            builder.ToTable("PEDIDOS");

            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.ValorTotal).IsRequired();

            builder.HasOne(p => p.Restaurante);
        }
    }
}