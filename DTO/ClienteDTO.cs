using DTO.ComplexTypes;
using System;

namespace DTO
{
    public class ClienteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public Endereco Endereco { get; set; }
    }
}