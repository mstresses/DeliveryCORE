using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
            using (var context = new DeliveryContext())
            {
                context.Produtos.Add(produto);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ProdutoDTO>> GetProdutos()
        {
            using (var context = new DeliveryContext())
            {
                return await context.Produtos.ToListAsync();
            }
        }
    }
}