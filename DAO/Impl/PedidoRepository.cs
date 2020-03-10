using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class PedidoRepository : IPedidoRepository
    {
        private DeliveryContext _context;
        public PedidoRepository(DeliveryContext context)
        {
            this._context = context;
        }

        public async Task Insert(PedidoDTO pedido)
        {
            this._context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PedidoDTO>> GetPedidos()
        {
            return await _context.Pedidos.ToListAsync();
        }
    }
}