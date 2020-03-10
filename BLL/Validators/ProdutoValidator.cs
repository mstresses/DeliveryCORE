using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoValidator()
        {
            RuleFor(r => r.Nome).NotNull().WithMessage("O nome deve ser informado.");

            RuleFor(r => r.Nome).MaximumLength(60).WithMessage("O nome deve ter no máximo 30 caracteres.");

            RuleFor(r => r.Restaurante).NotNull().WithMessage("O restaurante deve ser informado.");

            RuleFor(r => r.Valor).NotNull().WithMessage("O Valor deve ser informado.");

        }
    }
}
