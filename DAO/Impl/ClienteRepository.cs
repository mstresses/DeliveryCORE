using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClienteRepository : IClienteRepository
    {
        private DeliveryContext _context;
        public ClienteRepository(DeliveryContext context)
        {
            this._context = context;
        }

        public async Task Insert(ClienteDTO cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ClienteDTO>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}