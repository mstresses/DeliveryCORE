using Common;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Validators
{
    public class UsuarioValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioValidator()
        {
            List<Error> error = new List<Error>();

            RuleFor(u => u.Nome).NotNull().WithMessage("O nome deve ser informado.");
            error.Add(new Error() { FieldName = "Nome", Message = "Problema com o nome, verifique." });

            RuleFor(u => u.Email).NotNull().EmailAddress().WithMessage("O email deve ser informado.");
            error.Add(new Error() { FieldName = "Email", Message = "Problema com o Email, verifique." });

            RuleFor(u => u.Senha).NotNull().WithMessage("O CPF deve ser informado.");
            error.Add(new Error() { FieldName = "Senha", Message = "Problema com a Senha, verifique." });
            
            //if (error.Count > 0)
            //{
            //    File.WriteAllText("log.txt", error.ToString());
            //    throw new Exception("Erro no banco de dados, contate o administrador.");
            //}
        }
    }
}