using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DAO
{
    public class ProdutoRepository : IProdutoRepository
    {
        private DeliveryContext _context;
        public ProdutoRepository(DeliveryContext context)
        {
            this._context = context;
        }

        public async Task Insert(ProdutoDTO produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ProdutoDTO produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ProdutoDTO produto)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ProdutoDTO>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public async Task<List<ProdutoDTO>> GetProdutosByRestaurant(int id)
        {
            return await _context.Produtos.Where(c => c.Restaurante.ID == id).ToListAsync();
        }
    }
}