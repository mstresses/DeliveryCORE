using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProdutoDTO
    {
        public int ID { get; set; }
        public ProdutoDTO Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}