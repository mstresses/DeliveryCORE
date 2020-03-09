using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Insert
{
    public class ProdutoInsertViewModel
    {
        public ProdutoDTO Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}