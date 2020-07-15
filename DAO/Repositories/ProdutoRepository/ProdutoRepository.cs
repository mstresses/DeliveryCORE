using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;

namespace DAO.Repositories.ClienteRepository
{
    public class ProdutoRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProdutoRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }
    }
}