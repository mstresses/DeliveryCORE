using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Insert
{
    public class PedidoInsertViewModel
    {
        [DisplayName("Restaurante"), Required(ErrorMessage = "O restaurante deve ser informado.")]
        public RestauranteDTO Restaurante { get; set; }

        [DisplayName("Produto"), Required(ErrorMessage = "O produto deve ser informado.")]
        public ProdutoDTO Produto { get; set; }

        [DisplayName("Quantidade"), Required(ErrorMessage = "A quantidade deve ser informada.")]
        public double Quantidade { get; set; }

        [DisplayName("ValorTotal"), ReadOnly(true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = ("R$0,00"))]
        public double ValorTotal { get; set; }

        [DisplayName("TaxaEntrega"), Required(ErrorMessage = "A taxa de entrega deve ser informada.")]
        public bool TaxaEntrega { get; set; }

        [DisplayName("FormaPagamento"), Required(ErrorMessage = "A forma de pagamento deve ser informada.")]
        public FormaPagamento FormaPagamento { get; set; }
    }
}