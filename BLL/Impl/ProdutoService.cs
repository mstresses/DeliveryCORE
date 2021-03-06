﻿using BLL.Interfaces;
using BLL.Validators;
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
    public class ProdutoService : ProdutoValidator, IProdutoService
    {
        private IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public async Task Insert(ProdutoDTO produto)
        {
            try
            {
                await _produtoRepository.Insert(produto);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    List<Error> error = new List<Error>();
                    error.Add(new Error() { FieldName = "Produto", Message = "Produto já cadastrado" });
                    throw new Exception();
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task Update(ProdutoDTO produto)
        {
            try
            {
                await _produtoRepository.Update(produto);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task Delete(ProdutoDTO produto)
        {
            try
            {
                await _produtoRepository.Delete(produto);
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<List<ProdutoDTO>> GetProdutos()
        {
            return await _produtoRepository.GetProdutos();
        }

        public async Task<List<ProdutoDTO>> GetProductsByRestaurant(int id)
        {
            return await _produtoRepository.GetProdutosByRestaurant(id);
        }
    }
}