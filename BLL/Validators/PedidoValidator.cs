using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    public class PedidoValidator : AbstractValidator<PedidoDTO>
    {
        public PedidoValidator()
        {
            RuleFor(p => p.Produto).NotNull().WithMessage("Pedido vazio.");

            RuleFor(p => p.Quantidade).NotNull().LessThanOrEqualTo(0).WithMessage("A quantidade deve ser informada");

            RuleFor(p => p.ValorTotal).NotNull().LessThanOrEqualTo(0);

            RuleFor(p => p.TaxaEntrega).NotNull().WithMessage("A taxa de entrega deve ser informada"); ;

            RuleFor(p => p.FormaPagamento).NotNull().WithMessage("A forma de pagamento deve ser informada"); ;
        }
    }
}
