using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;

namespace DAO.Repositories.ClienteRepository
{
    public class RestauranteRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public RestauranteRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }
    }
}