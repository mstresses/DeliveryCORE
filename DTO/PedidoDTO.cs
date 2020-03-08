using DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PedidoDTO
    {
        public int ID { get; set; }
        public RestauranteDTO Restaurante { get; set; }
        public ProdutoDTO Produto { get; set; }
        public double Quantidade { get; set; }
        public double ValorTotal { get; set; }
        public bool TaxaEntrega { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
    }
}