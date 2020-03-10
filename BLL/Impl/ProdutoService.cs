using BLL.Interfaces;
using Common;
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
    public class ProdutoService : AbstractValidator<ProdutoDTO>, IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public async Task Insert(ProdutoDTO produto)
        {
            RuleFor(r => r.Nome).NotNull().WithMessage("O nome deve ser informado.");
            RuleFor(r => r.Nome).MaximumLength(60).WithMessage("O nome deve ter no máximo 30 caracteres.");

            RuleFor(r => r.Restaurante).NotNull().WithMessage("O restaurante deve ser informado.");

            RuleFor(r => r.Valor).NotNull().WithMessage("O Valor deve ser informado.");

            try
            {
                await _produtoRepository.Insert(produto);
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
       
        public async Task<List<ProdutoDTO>> GetProdutos()
        {
            return await _produtoRepository.GetProdutos();
        }
    }
}