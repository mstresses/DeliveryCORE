using DTO;

namespace BLL.Models.Autenticações
{
    public class UpdatePasswordRequestModel
    {
        public string Senha { get; set; }

        public Usuario Map()
        {
            return new Usuario(Senha);
        }
    }
}