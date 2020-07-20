namespace BLL.Models.Usuarios
{
    public abstract class UsuarioBaseModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}