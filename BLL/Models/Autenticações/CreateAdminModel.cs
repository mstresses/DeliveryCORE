namespace BLL.Models.Autenticações
{
    public class CreateAdminModel
    {
        public string Login { get; set; }

        public CreateAdminModel() { }

        public CreateAdminModel(string login)
        {
            Login = login;
        }
    }
}