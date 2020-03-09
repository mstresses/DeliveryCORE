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
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class RestauranteService : AbstractValidator<RestauranteDTO>, IRestauranteService
    {
        List<string> Erros = new List<string>();
        private IRestauranteRepository _restauranteRepository;

        public RestauranteService(IRestauranteRepository restauranteRepository)
        {
            this._restauranteRepository = restauranteRepository;
        }

        public async Task Insert(RestauranteDTO restaurante)
        {
            var resposta = restaurante.CNPJ.IsValidCNPJ();
            if (resposta != "") Erros.Add("CNPJ INVALIDO =" + resposta);

            RuleFor(r => r.NomeFantasia).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(r => r.NomeFantasia).MaximumLength(60).WithMessage("O nome deve ter no máximo 60 caracteres.");

            RuleFor(r => r.CNPJ).NotNull().WithMessage("O CNPJ deve ser informado.");
            RuleFor(r => r.CNPJ).Length(18);

            RuleFor(r => r.Telefone).NotNull().WithMessage("O telefone deve ser informado.");

            RuleFor(r => r.Categoria).NotNull().WithMessage("A categoria deve ser informada.");

            try
            {
                await _restauranteRepository.Insert(restaurante);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    List<Error> error = new List<Error>();
                    error.Add(new Error() { FieldName = "CNPJ", Message = "CNPJ já cadastrado" });
                    throw new Exception();
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<List<RestauranteDTO>> GetRestaurantes()
        {
            return await _restauranteRepository.GetRestaurantes();
        }
    }
}