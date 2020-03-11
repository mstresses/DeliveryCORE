using Common;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Validators
{
    public class PedidoValidator : AbstractValidator<PedidoDTO>
    {
        public PedidoValidator()
        {
            List<Error> error = new List<Error>();
            RuleFor(p => p.Restaurante).NotNull().WithMessage("Restaurante vazio.");
            error.Add(new Error() { FieldName = "Restaurante", Message = "Problema com o Restaurante, verifique." });

            RuleFor(p => p.Produto).NotNull().WithMessage("Pedido vazio.");
            error.Add(new Error() { FieldName = "Produto", Message = "Problema com o Produto, verifique." });

            RuleFor(p => p.Quantidade).NotNull().LessThanOrEqualTo(0).WithMessage("A quantidade deve ser informada");
            error.Add(new Error() { FieldName = "Quantidade", Message = "Problema com a quantidade, verifique." });

            RuleFor(p => p.ValorTotal).NotNull().LessThanOrEqualTo(0);
            error.Add(new Error() { FieldName = "ValorTotal", Message = "Problema com o valor, verifique." });

            RuleFor(p => p.TaxaEntrega).NotNull().WithMessage("A taxa de entrega deve ser informada"); ;
            error.Add(new Error() { FieldName = "TaxaEntrega", Message = "Problema com a taxa de entrega, verifique." });

            RuleFor(p => p.FormaPagamento).NotNull().WithMessage("A forma de pagamento deve ser informada"); ;
            error.Add(new Error() { FieldName = "FormaPagamento", Message = "Problema com a forma de pagamento, verifique." });
            
            //if (error.Count > 0)
            //{
            //    File.WriteAllText("log.txt", error.ToString());
            //    throw new Exception();
            //}
        }
    }
}