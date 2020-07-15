using BLL.Models.Produtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoResponseModel>> GetAll();
        //Task<IEnumerable<ProdutoResponseModel>> GetProdutosByRestaurantes(int id);
        Task<ProdutoResponseModel> GetById(int id);
        Task<ProdutoResponseModel> Create(ProdutoRequestModel produtoRequestModel);
        Task<ProdutoResponseModel> Update(int id, ProdutoRequestModel produtoRequestModel);
        Task Delete(int id);
    }
}