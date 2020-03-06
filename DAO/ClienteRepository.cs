using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ClienteRepository:IClienteRepository
    {
        public async Task<ClienteDTO> Authenticate(string email, string senha)
        {
            using (var ctx = new DeliveryContext())
            {
                ClienteDTO user = await ctx.Clientes.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
                if (user == null)
                {
                    throw new Exception("Email e/ou senha inválidos");
                }
                return user;

            }
        }

        public async Task Insert(ClienteDTO cliente)
        {
            using (var context = new DeliveryContext())
            {
                context.Clientes.Add(cliente);
                await context.SaveChangesAsync();
            }
        }
    }
}
