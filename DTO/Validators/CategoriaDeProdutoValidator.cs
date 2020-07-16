using DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class CategoriaDeProdutosValidator : AbstractValidator<CategoriaDeProduto>
    {
        public CategoriaDeProdutosValidator()
        {
            RuleFor(r => r.Nome).NotEmpty().WithMessage("A categoria deve ser informada.")
                                .MaximumLength(100).WithMessage("Número de caracteres excedido.");

            RuleFor(p => p.FornecedorId).NotEqual(0).WithMessage("O id da categoria não pode ser 0.");
        }
    }
}