using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class RestauranteDTO
    {
        public int ID { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        //public Endereco Endereco { get; set; }
        public string Categoria { get; set; }
    }
}