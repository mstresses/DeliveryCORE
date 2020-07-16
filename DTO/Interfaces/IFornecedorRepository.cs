using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IFornecedorRepository : IGenericRepository<Fornecedor>
    {
        Task<IEnumerable<Fornecedor>> GetAll();
    }
}