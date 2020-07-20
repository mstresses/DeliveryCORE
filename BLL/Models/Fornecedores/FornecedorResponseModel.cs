using BLL.Models.Enderecos;

namespace BLL.Models.Fornecedores
{
    public sealed class FornecedorResponseModel : FornecedorBaseModel
    {
        public int Id { get; set; }
        public bool Deleted { get; set; }

        public FornecedorResponseModel(int id, string razaoSocial, string cnpj, string nomeFantasia,
                                       string telefoneDeContato, string emailDeContato, bool isDeleted)
        {
            Id = id;
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            NomeFantasia = nomeFantasia;
            TelefoneDeContato = telefoneDeContato;
            EmailDeContato = emailDeContato;
            Deleted = isDeleted;
        }
    }
}