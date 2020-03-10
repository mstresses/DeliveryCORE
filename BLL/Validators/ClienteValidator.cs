using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class ClienteValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteValidator()
        {

            RuleFor(c => c.Nome).NotNull().WithMessage("O nome deve ser informado.");

            RuleFor(c => c.Email).NotNull().WithMessage("O email deve ser informado.");

            RuleFor(c => c.Telefone).NotNull().WithMessage("O telefone deve ser informado.");

            RuleFor(c => c.Cpf).NotNull().WithMessage("O CPF deve ser informado.");
        }
    }
}
