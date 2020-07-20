namespace BLL.Models.Usuarios
{
    public sealed class UsuarioResponseModel : UsuarioBaseModel
    {
        public UsuarioResponseModel(string login)
        {
            Login = login;
        }
    }
}