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
    public class ProdutoService : CategoriaDeProdutosValidator, IProdutoService
    {
        private ICategoriaDeProdutoRepository _produtoRepository;

        public ProdutoService(ICategoriaDeProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        private async Task<ProductCategoryResponseModel> GetResponse(CategoriaDeProduto produto)
        {
            return new ProductCategoryResponseModel(produto.Id, produto.Restaurante.NomeFantasia, produto.Nome, produto.Valor, produto.Deleted);
        }

        public async Task<IEnumerable<ProductCategoryResponseModel>> GetAll()
        {
            var produtos = await _produtoRepository.GetAll();

            return produtos.Select(p => new ProductCategoryResponseModel(p.Id, p.Restaurante.NomeFantasia.ToString(), p.Nome, p.Valor, p.Deleted));
        }

        public async Task<ProductCategoryResponseModel> GetById(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            return await GetResponse(produto);
        }

        public async Task<ProductCategoryResponseModel> Create(ProductCategoryRequestModel produtoRequestModel)
        {
            var produto = new CategoriaDeProduto(produtoRequestModel.Restaurante.NomeFantasia, produtoRequestModel.Nome, produtoRequestModel.Valor);

            produto.Validate();

            await _produtoRepository.Create(produto);

            return await GetResponse(produto);
        }

        public async Task<ProductCategoryResponseModel> Update(int id, ProductCategoryRequestModel produtoRequestModel)
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