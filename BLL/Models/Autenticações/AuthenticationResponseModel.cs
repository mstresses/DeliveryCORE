using BLL.Models.Usuarios;

namespace BLL.Models.Autenticações
{
    public class AuthenticationResponseModel
    {
        public UsuarioResponseModel Usuario { get; set; }
        public string Token { get; set; }
    }
}