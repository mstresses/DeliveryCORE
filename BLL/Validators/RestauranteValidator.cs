using Common;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Validators
{
    public class RestauranteValidator : AbstractValidator<RestauranteDTO>
    {
        public RestauranteValidator()
        {
            List<Error> error = new List<Error>();

            RuleFor(r => r.NomeFantasia).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(r => r.NomeFantasia).MaximumLength(60).WithMessage("O nome deve ter no máximo 60 caracteres.");
            error.Add(new Error() { FieldName = "Nome", Message = "Problema com o nome, verifique." });

            RuleFor(r => r.CNPJ).NotNull().Length(18).WithMessage("O CNPJ deve ser informado.");
            error.Add(new Error() { FieldName = "CNPJ", Message = "Problema com o CNPJ, verifique." });

            RuleFor(r => r.Telefone).NotNull().WithMessage("O telefone deve ser informado.");
            error.Add(new Error() { FieldName = "Telefone", Message = "Problema com o Telefone, verifique." });

            RuleFor(r => r.Categoria).NotNull().WithMessage("A categoria deve ser informada.");
            error.Add(new Error() { FieldName = "Categoria", Message = "Problema com a Categoria, verifique." });

            //if (error.Count > 0)
            //{
            //    throw new Exception();
            //}
        }
    }
}