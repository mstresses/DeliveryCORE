namespace BLL.Models.Enderecos
{
    public abstract class EnderecoBaseModel
    {
        public string Numero { get; set; }
        public string Rua { get; set; }
        public string UF { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
    }
}