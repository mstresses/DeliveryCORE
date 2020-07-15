using BLL.Validators;
using DTO.Entities.Base;
using FluentValidation;

namespace DTO
{
    public class Usuario : BaseEntity
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

        public Usuario() { }

        public Usuario(string email, string senha, string role)
        {
            Update(email, senha, role);
        }

        public void Update(string email, string senha, string role)
        {
            Email = email;
            Senha = senha;
            Role = role;
        }

        public void Validate()
        {
            var validar = new UsuarioValidator();
            validar.ValidateAndThrow(this);
        }
    }
}