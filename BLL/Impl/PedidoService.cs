using BLL.Interfaces;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class PedidoService : AbstractValidator<PedidoDTO>, IPedidoService
    {
        public async Task Insert(PedidoDTO pedido)
        {
            RuleFor(p => p.Quantidade).NotNull().LessThanOrEqualTo(0);
            RuleFor(p => p.ValorTotal).NotNull();
        }

        public async Task<List<PedidoDTO>> GetRestaurantes()
        {
            RuleFor(p => p.Quantidade).NotNull().WithMessage("A quantidade deve ser informada");
            RuleFor(p => p.ValorTotal).NotNull();
            RuleFor(p => p.TaxaEntrega).NotNull().WithMessage("A taa de entrega deve ser informada"); ;
            RuleFor(p => p.FormaPagamento).NotNull().WithMessage("A forma de pagamento deve ser informada"); ;
            
        }
    }
}
