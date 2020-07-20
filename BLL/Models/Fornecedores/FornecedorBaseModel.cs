using BLL.Models.Enderecos;
using DTO;
using System.Collections.Generic;

namespace BLL.Models.Fornecedores
{
    public abstract class FornecedorBaseModel
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string NomeFantasia { get; set; }
        public EnderecoBaseModel Endereco { get; set; }
        public string TelefoneDeContato { get; set; }
        public string EmailDeContato { get; set; }
        public virtual ICollection<CategoriaDeProduto> Produtos { get; set; }
    }
}