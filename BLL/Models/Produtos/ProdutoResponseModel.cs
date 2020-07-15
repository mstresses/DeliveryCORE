using DTO;

namespace BLL.Models.Produtos
{
    public sealed class ProdutoResponseModel : ProdutoBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public ProdutoResponseModel(int id, Restaurante restaurante, string nome, double valor, bool deleted)
        {
            Id = id;
            Restaurante.NomeFantasia = restaurante.NomeFantasia.ToString();
            Nome = nome;
            Deleted = deleted;
        }
    }
}