using DTO;
using FluentValidation;

namespace BLL.Validators
{
    public class FornecedorValidator : AbstractValidator<Fornecedor>
    {
        public FornecedorValidator()
        {
            RuleFor(s => s.RazaoSocial).NotEmpty().WithMessage("O nome deve ser informado.")
                                       .MaximumLength(100).WithMessage("Número de caracteres excedido.");

            RuleFor(s => s.Cnpj).NotEmpty().WithMessage("O CNPJ deve ser informado.")
                                .Must(IsValidCNPJ).WithMessage("CNPJ inválido.")
                                .Length(18).WithMessage("Número de caracteres excedido.");

            RuleFor(f => f.NomeFantasia).NotEmpty().WithMessage("O Nome Fantasia deve ser informado.")
                                        .MaximumLength(100).WithMessage("O Nome Fantasia deve conter no máximo 100 caracteres.");

            RuleFor(f => f.Endereco.Numero).NotEmpty().WithMessage("O número deve ser informada.");
                                           
            RuleFor(f => f.Endereco.Rua).NotEmpty().WithMessage("A rua deve ser informada.")
                                        .MaximumLength(100).WithMessage("Número de caracteres excedido.");
            RuleFor(f => f.Endereco.UF).NotEmpty().WithMessage("O UF deve ser informado.")
                                       .MaximumLength(2).WithMessage("Número de caracteres excedido.");
            RuleFor(f => f.Endereco.Pais).NotEmpty().WithMessage("O país deve ser informado.")
                                         .MaximumLength(100).WithMessage("Número de caracteres excedido.");
            RuleFor(f => f.Endereco.Cidade).NotEmpty().WithMessage("A cidade deve ser informada.")
                                           .MaximumLength(100).WithMessage("Número de caracteres excedido.");

            RuleFor(f => f.TelefoneDeContato).NotEmpty().WithMessage("O Telefone deve ser informado.");

            RuleFor(f => f.EmailDeContato).NotEmpty().WithMessage("O Email deve ser informado.")
                                          .EmailAddress().WithMessage("Digite um endereço de email válido.");
        }

        private bool IsValidCNPJ(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }
    }
}