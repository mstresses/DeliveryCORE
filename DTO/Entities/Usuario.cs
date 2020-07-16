using BLL.Validators;
using DTO.Entities.Base;
using DTO.Utils;
using FluentValidation;

namespace DTO
{
    public class Usuario : BaseEntity
    {
        public string Login { get; private set; }
        public string Senha { get; private set; }
        public bool IsAdmin { get; private set; }

        public Usuario() { }

        public Usuario(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public Usuario(string senha)
        {
            Senha = senha;
        }

        public async void HashSenha()
        {
            Senha = await new HashUtils().HashString(Senha);
        }

        public void UpdateSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        public void TornarAdmin()
        {
            if (!IsAdmin)
            {
                IsAdmin = true;
            }
        }
        public void Validate()
        {
            var validate = new UsuarioValidator();
            validate.ValidateAndThrow(this);
        }
    }
}