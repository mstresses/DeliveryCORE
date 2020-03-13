using BLL.Interfaces;
using BLL.Validators;
using Common;
using DAO.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : UsuarioValidator, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        public async Task Insert(UsuarioDTO usuario)
        {
            try
            {
                await _usuarioRepository.Create(usuario);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    error.Add(new Error() { FieldName = "Email", Message = "Email já cadastrado" });
                    throw new Exception();
                }
                
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<UsuarioDTO> Authenticate(string email, string senha)
        {
            return await _usuarioRepository.Authenticate(email, senha);
        }
    }
}