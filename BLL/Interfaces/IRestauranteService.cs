using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IRestauranteService
    {
        Task Insert(RestauranteDTO restaurante);
        Task Update(RestauranteDTO restaurante);
        Task Delete(RestauranteDTO restaurante);
        Task<List<RestauranteDTO>> GetRestaurantes();
        Task<List<RestauranteDTO>> GetRestaurantesByCategorias(string categoria);
    }
}