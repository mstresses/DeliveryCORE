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
            using (var context = new DeliveryContext())
            {
                context.Clientes.Add(cliente);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<ClienteDTO>> GetClientes()
        {
            using (var context = new DeliveryContext())
            {
                return await _context.Clientes.ToListAsync();
            }
        }

        public async Task<ClienteDTO> Authenticate(string email, string senha)
        {
            using (var context = new DeliveryContext())
            {
                ClienteDTO user = await context.Clientes.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
                if (user == null)
                {
                    throw new Exception("Email e/ou senha inválidos");
                }
                return user;
            }
        }
    }
}