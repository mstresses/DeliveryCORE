using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Models.Update
{
    public class ProdutoUpdateViewModel
    {
        public int RestauranteID { get; set; }

        [DisplayName("Nome"), Required(ErrorMessage = "O nome do produto deve ser informado.")]
        [StringLength(maximumLength: 100, MinimumLength = 3, ErrorMessage = "O nome do produto deve conter de 3 e 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("Valor"), Required(ErrorMessage = "O valor do produto deve ser informado.")]
        public double Valor { get; set; }
    }
}
