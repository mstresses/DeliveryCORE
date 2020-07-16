using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface ICategoriaDeProdutoRepository : IGenericRepository<CategoriaDeProduto>
    {
        Task<IEnumerable<CategoriaDeProduto>> GetAll();
    }
}