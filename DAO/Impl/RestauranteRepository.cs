using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RestauranteRepository : IRestauranteRepository
    {
        private DeliveryContext _context;

        public RestauranteRepository(DeliveryContext context) //Construtor com INJEÇÃO DE DEPENDENCIA.
        {
            this._context = context;
        }

        public async Task Insert(RestauranteDTO restaurante)
        {
            this._context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task Update(RestauranteDTO restaurante)
        {
            this._context.Restaurantes.Update(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(RestauranteDTO restaurante)
        {
            this._context.Restaurantes.Remove(restaurante);
            await _context.SaveChangesAsync();
        }

        public async Task<List<RestauranteDTO>> GetRestaurantes()
        {
            return await _context.Restaurantes.ToListAsync();
        }

        public async Task<List<RestauranteDTO>> GetRestaurantesByCategorias(string categoria)
        {
            return await _context.Restaurantes.Where(c=>c.Categoria == categoria).ToListAsync();
        }
    }
}