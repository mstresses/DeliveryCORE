using Microsoft.EntityFrameworkCore;

namespace DTO.Entities
{
    [Owned]
    public class Endereco
    {
        public string Numero { get; private set; }
        public string Rua { get; private set; }
        public string UF { get; private set; }
        public string Pais { get; private set; }
        public string Cidade { get; private set; }

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