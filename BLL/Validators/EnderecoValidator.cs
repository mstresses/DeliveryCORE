using Common;
using DTO.ComplexTypes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    internal class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(e => e.CEP).NotNull().WithMessage("O CEP deve ser informado.");

            RuleFor(e => e.Rua).NotNull().WithMessage("O nome da rua deve ser informado.");
            RuleFor(e => e.Rua).MaximumLength(30).WithMessage("O nome da rua deve conter no máximo 30 caracteres.");
            
            RuleFor(e => e.Bairro).NotNull().WithMessage("O bairro deve ser informado.");

            RuleFor(e => e.Cidade).NotNull().WithMessage("A cidade deve ser informada.");
            
            RuleFor(e => e.UF).NotNull().WithMessage("O UF deve ser informado.");
        }
    }
}