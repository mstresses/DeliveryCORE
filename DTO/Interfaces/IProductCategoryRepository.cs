using System.Collections.Generic;
using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        Task<IEnumerable<ProductCategory>> GetAll();
        Task<bool> VerifyIfProductCategoryExists(int id);
        Task SaveCustomIdentity();
        Task<bool> VerifyIfProductCategoryAlreadyExistsInSupplier(ProductCategory productCategory);
        Task<IEnumerable<ProductCategory>> GetAllIncludingSupplier();
    }
}