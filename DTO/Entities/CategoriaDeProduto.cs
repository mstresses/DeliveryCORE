using BLL.Validators;
using DTO.Entities.Base;
using FluentValidation;

namespace DTO
{
    public class CategoriaDeProduto : BaseEntity
    {
        public string Nome { get; set; }
        public virtual Fornecedor Fornecedor { get; protected set; }
        public int FornecedorId { get; set; }

        public CategoriaDeProduto()
        {
        }

        public CategoriaDeProduto(string nome, int fornecedorId)
        {
            Nome = nome;
            FornecedorId = fornecedorId;
        }

        public void Update(string nome)
        {
            Nome = nome;
        }

        public void Validate()
        {
            var validate = new CategoriaDeProdutosValidator();
            validate.ValidateAndThrow(this);
        }
    }
}