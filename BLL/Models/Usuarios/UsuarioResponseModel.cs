namespace BLL.Models.Usuarios
{
    public sealed class UsuarioResponseModel : UsuarioBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public UsuarioResponseModel(int id, string email, string role, bool deleted)
        {
            Id = id;
            Email = email;
            Role = role;
            Deleted = deleted;
        }
    }
}