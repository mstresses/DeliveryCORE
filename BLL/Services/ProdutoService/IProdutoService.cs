using BLL.Models.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProductCategoryResponseModel>> GetAll();
        //Task<IEnumerable<ProdutoResponseModel>> GetProdutosByRestaurantes(int id);
        Task<ProductCategoryResponseModel> GetById(int id);
        Task<ProductCategoryResponseModel> Create(ProductCategoryRequestModel produtoRequestModel);
        Task<ProductCategoryResponseModel> Update(int id, ProductCategoryRequestModel produtoRequestModel);
        Task Delete(int id);
    }
}