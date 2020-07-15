using BLL.Models.Usuarios;
using BLL.Services;
using BLL.Validators;
using DTO;
using DTO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class UsuarioService : UsuarioValidator, IUsuarioService
    {
        private IUserRepository _usuarioRepository;
        public UsuarioService(IUserRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }

        //public async Task<Usuario> Authenticate(string email, string senha)
        //{
        //    return await _usuarioRepository.Authenticate(email, senha);
        //}

        private async Task<UsuarioResponseModel> GetResponse(User usuario)
        {
            return new UsuarioResponseModel(usuario.Id, usuario.Email, usuario.Role, usuario.Deleted);
        }

        public async Task<IEnumerable<UsuarioResponseModel>> GetAll()
        {
            var usuarios = await _usuarioRepository.GetAll();

            return usuarios.Select(u => new UsuarioResponseModel(u.Id, u.Email, u.Role, u.Deleted));
        }

        public async Task<UsuarioResponseModel> GetById(int id)
        {
            var fornecedor = await _usuarioRepository.GetById(id);

            return await GetResponse(fornecedor);
        }

        public async Task<UsuarioResponseModel> Create(UsuarioRequestModel usuarioRequestModel)
        {
            var usuario = new User(usuarioRequestModel.Email, usuarioRequestModel.Senha, usuarioRequestModel.Role);

            usuario.Validate();

            await _usuarioRepository.Create(usuario);

            return await GetResponse(usuario);
        }

        public async Task<UsuarioResponseModel> Update(int id, UsuarioRequestModel usuarioRequestModel)
        {
            var usuario = await _usuarioRepository.GetById(id);

            usuario.Update(usuarioRequestModel.Email, usuarioRequestModel.Senha, usuarioRequestModel.Role);

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