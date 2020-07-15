using Microsoft.EntityFrameworkCore;

namespace DAO.Context
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions options) : base(options) { }

        public DeliveryContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DeliveryContext).Assembly);

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("DefaultConnection");
            }
        }
    }
}