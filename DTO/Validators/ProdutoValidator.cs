using DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class ProdutoValidator : AbstractValidator<ProductCategory>
    {
        public ProdutoValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage("O produto deve ser informado.")
                                .MaximumLength(60).WithMessage("Número de caracteres excedido.");


            RuleFor(r => r.Restaurante).NotEmpty().WithMessage("O restaurante deve ser informado.");

            RuleFor(r => r.Valor).NotEmpty().WithMessage("O Valor deve ser informado.");
        }
    }
}