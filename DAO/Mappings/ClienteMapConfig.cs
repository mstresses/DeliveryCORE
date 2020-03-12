using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class ClienteMapConfig : IEntityTypeConfiguration<ClienteDTO>
    {
        public void Configure(EntityTypeBuilder<ClienteDTO> builder)
        {
            builder.ToTable("CLIENTES");

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(60);

            builder.Property(c => c.Cpf).IsRequired().HasMaxLength(14);
            builder.HasIndex(c => c.Cpf).IsUnique();

            builder.Property(c => c.DataNascimento).IsRequired();
            
            builder.Property(c => c.Email).IsRequired().HasMaxLength(60);
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Telefone).IsRequired().HasMaxLength(20);
            builder.HasIndex(c => c.Telefone).IsUnique();

            builder.Property(c => c.Senha).IsRequired().HasMaxLength(20);
        }
    }
}