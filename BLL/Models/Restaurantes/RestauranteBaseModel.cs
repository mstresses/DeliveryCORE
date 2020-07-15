using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Models.Restaurantes
{
    public abstract class RestauranteBaseModel
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Categoria { get; set; }
        public virtual ICollection<ProductCategory> Produtos { get; set; }
    }
}