using BLL.Validators;
using DTO.Entities.Base;
using FluentValidation;

namespace DTO
{
    public class CategoriaDeProduto : BaseEntity
    {
        public string Nome { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        public CategoriaDeProduto()
        {
        }

        public CategoriaDeProduto(string nome, Fornecedor fornecedor, int fornecedorId)
        {
            Nome = nome;
            Fornecedor = fornecedor;
            FornecedorId = fornecedorId;
        }

        public CategoriaDeProduto(string nome, int fornecedorId)
        {
            Nome = nome;
            FornecedorId = fornecedorId;
        }

        public void Validate()
        {
            var validate = new CategoriaDeProdutosValidator();
            validate.ValidateAndThrow(this);
        }
    }
}