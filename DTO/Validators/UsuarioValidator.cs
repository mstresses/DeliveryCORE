using DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Login).NotEmpty().WithMessage("O email deve ser informado.")
                                 .EmailAddress().WithMessage("Email inválido.")
                                 .MaximumLength(100).WithMessage("Número de caracteres excedido.");

            RuleFor(u => u.Senha).NotEmpty().WithMessage("A senha deve ser informada.")
                                 .MaximumLength(15).WithMessage("Número de caracteres excedido.");
        }
    }
}