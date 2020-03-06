using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RestauranteRepository : IRestauranteRepository
    {
        public async Task Insert(RestauranteDTO restaurante)
        {
            using (var context = new DeliveryContext())
            {
                context.Restaurantes.Add(restaurante);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<RestauranteDTO>> GetRestaurantes()
        {
            using (var context = new DeliveryContext())
            {
                return await context.Restaurantes.ToListAsync();
            }
        }
    }
}