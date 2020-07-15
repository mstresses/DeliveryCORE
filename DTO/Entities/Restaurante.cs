using BLL.Validators;
using DTO.Entities.Base;
using FluentValidation;
using System.Collections.Generic;

namespace DTO
{
    public class Restaurante : BaseEntity
    {
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Categoria { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public Restaurante() { }

        public Restaurante(string nomeFantasia, string cnpj, string telefone, string endereco, string categoria)
        {
            Update(nomeFantasia, telefone, endereco, categoria);
        }

        public void Update(string nomeFantasia, string telefone, string endereco, string categoria)
        {
            NomeFantasia = nomeFantasia;
            Telefone = telefone;
            Endereco = endereco;
            Categoria = categoria;
        }

        public void Validate()
        {
            var validar = new RestauranteValidator();
            validar.ValidateAndThrow(this);
        }
    }
}