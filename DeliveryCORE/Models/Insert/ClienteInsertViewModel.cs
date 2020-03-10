using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeliveryCORE.Models.Insert
{
    public class ClienteInsertViewModel
    {
        [DisplayName("Nome"), Required(ErrorMessage = "O nome deve ser informado")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "O nome deve conter de 3 e 100 caracteres")]
        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy")]
        [DisplayName("DataNascimento"), Required(ErrorMessage = "A data de nascimento deve ser informada")]
        public DateTime DataNascimento { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "O email deve ser informado")]
        public string Email { get; set; }

        [DisplayName("Telefone"), Required(ErrorMessage = "O telefone deve ser informado")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "O telefone deve conter no minimo 10 caracteres")]
        public string Telefone { get; set; }

        [DisplayName("Cpf"), Required(ErrorMessage = "O CPF deve ser informado")]
        public string Cpf { get; set; }

        //[DisplayName("Endereco"), Required(ErrorMessage = "O endereco deve ser informado")]
        //[StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "O endereco deve conter no minimo 8 e no máximo 100 caracteres.")]
        //public Endereco Endereco { get; set; }

        [DisplayName("Senha"), Required(ErrorMessage = "A senha deve ser informado")]
        [StringLength(maximumLength: 15, MinimumLength = 6, ErrorMessage = "A senha deve conter no minimo 6 e no máximo 15 caracteres.")]
        public string Senha { get; set; }
    }
}