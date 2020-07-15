namespace BLL.Models.Restaurantes
{
    public sealed class RestauranteResponseModel : RestauranteBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public RestauranteResponseModel(int id, string nomeFantasia, string cnpj, string telefone,
                                        string endereco, string categoria, bool deleted)
        {
            Id = id;
            NomeFantasia = nomeFantasia;
            CNPJ = cnpj;
            Telefone = telefone;
            Endereco = endereco;
            Categoria = categoria;
            Deleted = deleted;
        }
    }
}