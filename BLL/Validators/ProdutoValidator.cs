using Common;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Validators
{
    public class ProdutoValidator : AbstractValidator<ProdutoDTO>
    {
        public ProdutoValidator()
        {
            List<Error> error = new List<Error>();

            RuleFor(r => r.Nome).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(r => r.Nome).MaximumLength(60).WithMessage("O nome deve ter no máximo 30 caracteres.");
            error.Add(new Error() { FieldName = "Nome", Message = "Problema com o nome, verifique." });

            RuleFor(r => r.Restaurante).NotNull().WithMessage("O restaurante deve ser informado.");
            error.Add(new Error() { FieldName = "Restaurante", Message = "Problema com o Restaurante, verifique." });

            RuleFor(r => r.Valor).NotNull().WithMessage("O Valor deve ser informado.");
            error.Add(new Error() { FieldName = "Valor", Message = "Problema com o Valor, verifique." });
           
            //if (error.Count > 0)
            //{
            //    File.WriteAllText("log.txt", error.ToString());
            //    throw new Exception();
            //}
        }
    }
}