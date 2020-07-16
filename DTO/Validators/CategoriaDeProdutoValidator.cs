using DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class CategoriaDeProdutosValidator : AbstractValidator<CategoriaDeProduto>
    {
        public CategoriaDeProdutosValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage("Category must be informed.")
                                .MaximumLength(60).WithMessage("Number of characters exceeded.");

            RuleFor(p => p.FornecedorId).NotEqual(0).WithMessage("product category id cannot be zero");
        }
    }
}