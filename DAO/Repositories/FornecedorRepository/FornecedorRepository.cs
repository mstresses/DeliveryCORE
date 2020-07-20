using DAO.Context;
using DAO.Repositories.GenericRepository;
using DTO;
using DTO.Interfaces;

namespace DAO.Repositories.FornecedorRepository
{
    public class FornecedorRepository : GenericRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MainContext dbContext) : base(dbContext)
        {
        }
    }
}