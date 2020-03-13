using DAO.Interfaces;
using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace DAO.Impl
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private DeliveryContext _context;
        public UsuarioRepository(DeliveryContext context)
        {
            this._context = context;
        }

        public async Task Create(UsuarioDTO usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("Email"))
                {
                    throw new Exception("O email já foi cadastrado.");
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados");
            }
        }

        public async Task<UsuarioDTO> Authenticate(string email, string senha)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
            if (_context == null)
            {
                throw new Exception("Email e/ou senha inválidos");
            }
            return user;

            //using (var ctx = new DeliveryContext())
            //{
            //    UsuarioDTO user = await ctx.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);
            //    if (user == null)
            //    {
            //        throw new Exception("Email e/ou senha inválidos");
            //    }
            //    return user;
            //}
        }
    }
}