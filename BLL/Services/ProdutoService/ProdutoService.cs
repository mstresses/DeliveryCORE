using BLL.Models.Produtos;
using BLL.Services;
using BLL.Validators;
using DTO;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class ProdutoService : ProdutoValidator, IProdutoService
    {
        private IProductCategoryRepository _produtoRepository;

        public ProdutoService(IProductCategoryRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        private async Task<ProdutoResponseModel> GetResponse(ProductCategory produto)
        {
            return new ProdutoResponseModel(produto.Id, produto.Restaurante.NomeFantasia, produto.Nome, produto.Valor, produto.Deleted);
        }

        public async Task<IEnumerable<ProdutoResponseModel>> GetAll()
        {
            var produtos = await _produtoRepository.GetAll();

            return produtos.Select(p => new ProdutoResponseModel(p.Id, p.Restaurante.NomeFantasia.ToString(), p.Nome, p.Valor, p.Deleted));
        }

        public async Task<ProdutoResponseModel> GetById(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            return await GetResponse(produto);
        }

        public async Task<ProdutoResponseModel> Create(ProdutoRequestModel produtoRequestModel)
        {
            var produto = new ProductCategory(produtoRequestModel.Restaurante.NomeFantasia, produtoRequestModel.Nome, produtoRequestModel.Valor);

            produto.Validate();

            await _produtoRepository.Create(produto);

            return await GetResponse(produto);
        }

        public async Task<ProdutoResponseModel> Update(int id, ProdutoRequestModel produtoRequestModel)
        {
            var produto = await _produtoRepository.GetById(id);

            produto.Update(produtoRequestModel.Nome, produtoRequestModel.Valor);

            produto.Validate();

            await _produtoRepository.Update(produto);

            return await GetResponse(produto);
        }

        public async Task Delete(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            produto.Delete();

            await _produtoRepository.Update(produto);
        }
    }
}