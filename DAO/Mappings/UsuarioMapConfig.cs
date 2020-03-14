using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    internal class UsuarioMapConfig : IEntityTypeConfiguration<UsuarioDTO>
    {
        public void Configure(EntityTypeBuilder<UsuarioDTO> builder)
        {
            builder.ToTable("USUARIOS");

            builder.Property(u => u.Email).HasMaxLength(100);
            builder.HasIndex(u => u.Email).IsUnique(true).HasName("UQ_USUARIO_EMAIL");

            builder.Property(u => u.Senha).HasMaxLength(15);
        }
    }
}