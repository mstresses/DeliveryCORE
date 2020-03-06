using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProdutoService
    {
        Task Insert(ProdutoDTO produto);
        Task<List<ProdutoDTO>> GetProdutos();
    }
}
