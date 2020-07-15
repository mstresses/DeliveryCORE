using DTO;

namespace BLL.Models.Produtos
{
    public abstract class ProdutoBaseModel
    {
        public int RestauranteID { get; set; }
        public Restaurante Restaurante { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
    }
}