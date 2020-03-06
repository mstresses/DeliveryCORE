using BLL.Interfaces;
using DAO;
using DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ClienteService : AbstractValidator<ClienteDTO>, IClienteService
    {
        public Task<List<ClienteDTO>> GetRestaurantes()
        {
            throw new NotImplementedException();
        }

        public async Task Insert(ClienteDTO cliente)
        {
            RuleFor(c => c.Nome).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(c => c.Email).NotNull().WithMessage("O email deve ser informado.");
            RuleFor(c => c.Telefone).NotNull().WithMessage("O telefone deve ser informado.");
            RuleFor(c => c.Cpf).NotNull().WithMessage("O CPF deve ser informado.");

        }
    }
}
