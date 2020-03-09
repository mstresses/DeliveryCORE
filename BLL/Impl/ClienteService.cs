using BLL.Interfaces;
using Common;
using Common.Extensions;
using DAO;
using DAO.Interfaces;
using DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : AbstractValidator<ClienteDTO>, IClienteService
    {
        List<string> Erros = new List<string>();
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task Insert(ClienteDTO cliente)
        {
            var resposta = cliente.Cpf.IsValidCPF();
            if (resposta != "") Erros.Add("CPF INVALIDO =" + resposta);

            RuleFor(c => c.Nome).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(c => c.Email).NotNull().WithMessage("O email deve ser informado.");
            RuleFor(c => c.Telefone).NotNull().WithMessage("O telefone deve ser informado.");
            RuleFor(c => c.Cpf).NotNull().WithMessage("O CPF deve ser informado.");

            try
            {
                await _clienteRepository.Insert(cliente);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    List<Error> error = new List<Error>();
                    error.Add(new Error() { FieldName = "CPF", Message = "CPF já cadastrado" });
                    throw new Exception();
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<List<ClienteDTO>> GetClientes()
        {
            return await _clienteRepository.GetClientes();
        }
    }
}