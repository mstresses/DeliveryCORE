using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRestauranteService
    {
        Task Insert(ProdutoDTO restaurante);

        Task<List<ProdutoDTO>> GetRestaurantes();
    }
}