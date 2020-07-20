using BLL.Models.Usuarios;
using BLL.Validators;
using DTO;
using DTO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.UsuarioService
{
    public class UsuarioService : UsuarioValidator, IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        //public async Task<Usuario> Authenticate(string email, string senha)
        //{
        //    return await _usuarioRepository.Authenticate(email, senha);
        //}

        private async Task<UsuarioResponseModel> GetResponse(Usuario usuario)
        {
            return new UsuarioResponseModel(usuario.Login);
        }

        public async Task<IEnumerable<UsuarioResponseModel>> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAll();

            return usuarios.Select(u => new UsuarioResponseModel(u.Login));
        }

        public async Task<UsuarioResponseModel> GetById(int id)
        {
            var fornecedor = await _usuarioRepository.GetById(id);

            return await GetResponse(fornecedor);
        }

        public async Task<UsuarioResponseModel> Create(UsuarioRequestModel usuarioRequestModel)
        {
            var usuario = new Usuario(usuarioRequestModel.Login, usuarioRequestModel.Senha);

            usuario.Validate();

            await _usuarioRepository.Create(usuario);

            return await GetResponse(usuario);
        }

        public async Task<UsuarioResponseModel> Update(int id, UsuarioRequestModel usuarioRequestModel)
        {
            var usuario = await _usuarioRepository.GetById(id);

            usuario.Update(usuarioRequestModel.Login, usuarioRequestModel.Senha);

            usuario.Validate();

            await _usuarioRepository.Update(usuario);

            return await GetResponse(usuario);
        }

        public async Task Delete(int id)
        {
            var usuario = await _usuarioRepository.GetById(id);

            usuario.Delete();

            await _usuarioRepository.Update(usuario);
        }
    }
}