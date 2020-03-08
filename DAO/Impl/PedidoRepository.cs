using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            using (var context = new DeliveryContext())
            {
                this._context.Pedidos.Add(pedido);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<PedidoDTO>> GetPedidos()
        {
            using (var context = new DeliveryContext())
            {
                return await _context.Pedidos.ToListAsync();
            }
        }
    }
}