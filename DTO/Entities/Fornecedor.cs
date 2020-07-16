using BLL.Validators;
using DTO.Entities;
using DTO.Entities.Base;
using FluentValidation;

namespace DTO
{
    public class Fornecedor : BaseEntity
    {
        public string RazaoSocial { get; protected set; }
        public string Cnpj { get; protected set; }
        public string NomeFantasia { get; protected set; }
        public Endereco Endereco { get; protected set; }
        public string TelefoneDeContato { get; protected set; }
        public string EmailDeContato { get; protected set; }

        protected Fornecedor() { }

        public Fornecedor(string razaoSocial, string cnpj, string nomeFantasia, Endereco endereco, string telefoneDeContato, string emailDeContato)
        {
            Update(nomeFantasia, endereco, telefoneDeContato, emailDeContato);
        }

        public void Update(string nomeFantasia, Endereco endereco, string telefoneContato, string emailContato)
        {
            NomeFantasia = nomeFantasia;
            Endereco = endereco;
            TelefoneDeContato = telefoneContato;
            EmailDeContato = emailContato;
        }

        public void Validate()
        {
            var validar = new FornecedorValidator();
            validar.ValidateAndThrow(this);
        }
    }
}