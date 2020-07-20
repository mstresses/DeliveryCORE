namespace BLL.Models.CategoriaDeProdutos
{
    public abstract class CategoriaDeProdutoBaseModel
    {
        public string Nome { get; set; }
        public int FornecedorId { get; set; }
    }
}