namespace BLL.Models.CategoriaDeProdutos
{
    public sealed class CategoriaDeProdutoResponseModel : CategoriaDeProdutoBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public CategoriaDeProdutoResponseModel(int id, string nome, int fornecedorId, bool deleted)
        {
            Id = id;
            Nome = nome;
            FornecedorId = fornecedorId;
            Deleted = deleted;
        }
    }
}