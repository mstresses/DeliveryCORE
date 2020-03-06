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
        private DeliveryContext _context;

        public RestauranteRepository(DeliveryContext context) //Contrutor com INJEÇÃO DE DEPENDENCIA.
        {
            this._context = context;
        }

        public async Task Insert(ProdutoDTO restaurante)
        {
            using (var context = new DeliveryContext())
            {
                this._context.Restaurantes.Add(restaurante);
                await context.SaveChangesAsync();
            }
        } 

        public async Task<List<ProdutoDTO>> GetRestaurantes()
        {
            using (var context = new DeliveryContext())
            {
                return await _context.Restaurantes.ToListAsync();
            }
        }
    }
}