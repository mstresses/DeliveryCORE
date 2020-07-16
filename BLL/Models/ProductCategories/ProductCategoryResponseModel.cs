using DTO;

namespace BLL.Models.Produtos
{
    public sealed class ProductCategoryResponseModel : ProductCategoryBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public ProductCategoryResponseModel(int id, Fornecedor restaurante, string nome, double valor, bool deleted)
        {
            Id = id;
            Restaurante.NomeFantasia = restaurante.NomeFantasia.ToString();
            Nome = nome;
            Deleted = deleted;
        }
    }
}