using BLL.Models.CategoriaDeProdutos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.CategoriaDeProdutoService
{
    public interface ICategoriaProdutoService
    {
        Task<IEnumerable<CategoriaDeProdutoResponseModel>> GetAll();
        Task<CategoriaDeProdutoResponseModel> GetById(int id);
        Task<CategoriaDeProdutoResponseModel> Create(CategoriaDeProdutoRequestModel produtoRequestModel);
        Task<CategoriaDeProdutoResponseModel> Update(int id, CategoriaDeProdutoRequestModel produtoRequestModel);
        Task Delete(int id);
    }
}