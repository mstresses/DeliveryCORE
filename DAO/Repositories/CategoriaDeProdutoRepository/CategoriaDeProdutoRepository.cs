using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;

namespace DAO.Repositories.ClienteRepository
{
    public class CategoriaDeProdutoRepository : GenericRepository<CategoriaDeProduto>, ICategoriaDeProdutoRepository
    {
        public CategoriaDeProdutoRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}