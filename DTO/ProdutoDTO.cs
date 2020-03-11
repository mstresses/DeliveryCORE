using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProdutoDTO
    {
        public int ID { get; set; }
        public int RestauranteID { get; set; }
        public RestauranteDTO Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}