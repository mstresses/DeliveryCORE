using DTO.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models
{
    public class RestauranteInsertViewModel
    {
        [DisplayName("NomeFantasia"), Required(ErrorMessage = ("O nome deve ser informado."))]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "O nome do restaurante deve conter entre 2 e 30 caracteres.")]
        public string NomeFantasia { get; set; }

        [DisplayName("CNPJ"), Required(ErrorMessage = ("O CNPJ deve ser informado."))]
        [StringLength(maximumLength: 18, MinimumLength = 2, ErrorMessage = "O CNPJ deve conter no máximo 18 caracteres.")]
        public string CNPJ { get; set; }

        [DisplayName("Telefone"), Required(ErrorMessage = "O telefone deve ser informado")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "O telefone deve conter no minimo 10 caracteres")]
        public string Telefone { get; set; }

        //public Endereco Endereco { get; set; }

        [DisplayName("Categoria"), Required(ErrorMessage = ("A categoria deve ser informada."))]
        [StringLength(maximumLength: 30, MinimumLength = 2, ErrorMessage = "A categoria do restaurante deve conter entre 2 e 30 caracteres.")]
        public string Categoria { get; set; }
    }
}