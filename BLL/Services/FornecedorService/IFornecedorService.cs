using BLL.Models.Fornecedores;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.FornecedorService
{
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorResponseModel>> GetAll();
        Task<FornecedorResponseModel> GetById(int id);
        Task<FornecedorResponseModel> Create(FornecedorRequestModel fornecedorRequestModel);
        Task<FornecedorResponseModel> Update(int id, FornecedorRequestModel fornecedorRequestModel);
        Task Delete(int id);
    }
}