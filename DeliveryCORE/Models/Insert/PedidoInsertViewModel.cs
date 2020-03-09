using DTO;
using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Insert
{
    public class PedidoInsertViewModel
    {
        public RestauranteDTO Restaurante { get; set; }
        public ProdutoDTO Produto { get; set; }
        public double Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public bool TaxaEntrega { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}