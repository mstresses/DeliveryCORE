using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IRestauranteRepository
    {
        Task Insert(RestauranteDTO restaurante);
        Task Update(RestauranteDTO restaurante);
        Task Delete(RestauranteDTO restaurante);
        Task<List<RestauranteDTO>> GetRestaurantes();
    }
}