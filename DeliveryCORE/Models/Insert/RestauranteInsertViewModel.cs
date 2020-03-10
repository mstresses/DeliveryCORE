using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models
{
    public class RestauranteInsertViewModel
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public string Categoria { get; set; }
    }
}