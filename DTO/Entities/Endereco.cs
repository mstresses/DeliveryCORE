namespace DTO.Entities
{
    public class Endereco
    {
        public string Numero { get; protected set; }
        public string Rua { get; protected set; }
        public string UF { get; protected set; }
        public string Pais { get; protected set; }
        public string Cidade { get; protected set; }

        public Endereco() { }

        public Endereco(string numero, string rua, string cidade, string uf, string pais)
        {
            Numero = numero;
            Rua = rua;
            Cidade = cidade;
            UF = uf;
            Pais = pais;
        }
    }
}