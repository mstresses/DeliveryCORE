using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Query
{
    public class ProdutoQueryViewModel
    {
        public int ID { get; set; }
        public Supplier Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}