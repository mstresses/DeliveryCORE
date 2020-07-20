using DAO.Context;
using DAO.Repositories.GenericRepository;
using DTO;
using DTO.Interfaces;

namespace DAO.Repositories.CategoriaDeProdutoRepository
{
    public class CategoriaDeProdutoRepository : GenericRepository<CategoriaDeProduto>, ICategoriaDeProdutoRepository
    {
        public CategoriaDeProdutoRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}