using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IProdutoRepository
    {
        Task Insert(ProdutoDTO produto);
        Task Update(ProdutoDTO produto);
        Task Delete(ProdutoDTO produto);
        Task<List<ProdutoDTO>> GetProdutos();
        Task<List<ProdutoDTO>> GetProdutosByRestaurant(int id);
    }
}