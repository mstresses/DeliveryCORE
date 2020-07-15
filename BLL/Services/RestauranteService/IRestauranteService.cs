using BLL.Models.Restaurantes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IRestauranteService
    {
        Task<IEnumerable<RestauranteResponseModel>> GetRestaurantes();
        Task<IEnumerable<RestauranteResponseModel>> GetRestaurantesByCategoria(string categoria);
        Task<RestauranteResponseModel> GetById(int id);
        Task<RestauranteResponseModel> Create(RestauranteRequestModel restauranteRequestModel);
        Task<RestauranteResponseModel> Update(int id, RestauranteRequestModel restauranteRequestModel);
        Task Delete(int id);
    }
}