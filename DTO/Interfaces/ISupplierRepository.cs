using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface ISupplierRepository : IGenericRepository<Supplier>
    {
        Task<IEnumerable<Supplier>> GetAll();
        Task<bool> SupplierExists(int id);
        Task<bool> VerifyIfSupplierEmailAlredyExists(Supplier entity);
        Task<bool> VerifyIfSupplierCNPJAlredyExists(Supplier entity);
    }
}