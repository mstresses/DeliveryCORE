using BLL.Interfaces;
using BLL.Validators;
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
    public class ClienteService : ClienteValidator, IClienteService
    {
        private IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public async Task Insert(ClienteDTO cliente)
        {
            
            try
            {
                await _clienteRepository.Insert(cliente);
            }
            catch (Exception ex)
            {
                List<Error> error = new List<Error>();

                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    error.Add(new Error() { FieldName = "CPF", Message = "CPF já cadastrado" });
                    throw new Exception();
                }

                var resposta = cliente.Cpf.IsValidCPF();
                if (resposta != "") error.Add(new Error() { FieldName = "CPF", Message = "CPF INVÁLIDO =" + resposta });

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