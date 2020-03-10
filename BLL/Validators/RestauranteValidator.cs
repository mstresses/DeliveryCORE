using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class RestauranteValidator : AbstractValidator<RestauranteDTO>
    {
        public RestauranteValidator()
        {
            RuleFor(r => r.NomeFantasia).NotNull().WithMessage("O nome deve ser informado.");

            RuleFor(r => r.NomeFantasia).MaximumLength(60).WithMessage("O nome deve ter no máximo 60 caracteres.");

            RuleFor(r => r.CNPJ).NotNull().WithMessage("O CNPJ deve ser informado.");

            RuleFor(r => r.CNPJ).Length(18);

            RuleFor(r => r.Telefone).NotNull().WithMessage("O telefone deve ser informado.");

            RuleFor(r => r.Categoria).NotNull().WithMessage("A categoria deve ser informada.");
        }
    }
}
