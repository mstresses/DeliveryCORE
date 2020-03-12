using Common;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.Validators
{
    public class ClienteValidator : AbstractValidator<ClienteDTO>
    {
        public ClienteValidator()
        {
            List<Error> error = new List<Error>();

            RuleFor(c => c.Nome).NotNull().WithMessage("O nome deve ser informado.");
            error.Add(new Error() { FieldName = "Nome", Message = "Problema com o nome, verifique." });

            RuleFor(c => c.Email).NotNull().EmailAddress().WithMessage("O email deve ser informado.");
            error.Add(new Error() { FieldName = "Email", Message = "Problema com o Email, verifique." });

            RuleFor(c => c.Telefone).NotNull().WithMessage("O telefone deve ser informado.");
            error.Add(new Error() { FieldName = "Telefone", Message = "Problema com o Telefone, verifique." });

            RuleFor(c => c.Cpf).NotNull().WithMessage("O CPF deve ser informado.");
            error.Add(new Error() { FieldName = "Cpf", Message = "Problema com o Cpf, verifique." });

            //if (error.Count > 0)
            //{
            //    File.WriteAllText("log.txt", error.ToString());
            //    throw new Exception("Erro no banco de dados, contate o administrador.");
            //}
        }
    }
}