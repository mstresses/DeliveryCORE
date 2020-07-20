using BLL.Models.Usuarios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services.UsuarioService
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseModel>> GetAll();
        Task<UsuarioResponseModel> GetById(int id);
        Task<UsuarioResponseModel> Create(UsuarioRequestModel usuarioRequestModel);
        Task<UsuarioResponseModel> Update(int id, UsuarioRequestModel usuarioRequestModel);
        Task Delete(int id);

        //      Task<Usuario> Authenticate(string email, string senha);

    }
}