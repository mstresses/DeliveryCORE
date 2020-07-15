using BLL.Validators;
using DTO.Entities.Base;
using FluentValidation;

namespace DTO
{
    public class Produto : BaseEntity
    {
        public int RestauranteID { get; set; }
        public Restaurante Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public Produto() { }

        public Produto(Restaurante restaurante, string nome, double valor)
        {
            Update(nome, valor);
        }

        public void Update(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public void Validate()
        {
            var validar = new ProdutoValidator();
            validar.ValidateAndThrow(this);
        }
    }
}