namespace BLL.Models.Enderecos
{
    public sealed class EnderecoResponseModel : EnderecoBaseModel
    {
        public EnderecoResponseModel(string numero, string rua, string uf, string pais, string cidade)
        {
            Numero = numero;
            Rua = rua;
            UF = uf;
            Pais = pais;
            Cidade = cidade;
        }
    }
}