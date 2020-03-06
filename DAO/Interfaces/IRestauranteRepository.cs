using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IRestauranteRepository
    {
        Task Insert(ProdutoDTO restaurante);

        Task<List<ProdutoDTO>> GetRestaurantes();
    }
}