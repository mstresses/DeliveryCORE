using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Query
{
    public class PedidoQueryViewModel
    {
        public Restaurante Restaurante { get; set; }
        public Produto Produto { get; set; }
        public double Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public bool TaxaEntrega { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}
