using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DAO
{
    public class DeliveryContext : DbContext
    {
      
        public DeliveryContext(DbContextOptions<DeliveryContext> aaaa):base(aaaa)
        {
        }

        public DbSet<ClienteDTO> Clientes { get; set; }
        public DbSet<RestauranteDTO> Restaurantes { get; set; }
        public DbSet<ProdutoDTO> Produtos { get; set; }
        public DbSet<PedidoDTO> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //UTILIZAR REFLECTION PARA CRIAR CONFIGURAÇÕES GLOBAIS

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}