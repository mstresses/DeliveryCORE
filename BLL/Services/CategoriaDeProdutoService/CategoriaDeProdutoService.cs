using BLL.Models.CategoriaDeProdutos;
using BLL.Validators;
using DTO;
using DTO.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.CategoriaDeProdutoService
{
    public class CategoriaDeProdutoService : CategoriaDeProdutosValidator, ICategoriaDeProdutoService
    {
        private ICategoriaDeProdutoRepository _produtoRepository;

        public CategoriaDeProdutoService(ICategoriaDeProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        private async Task<CategoriaDeProdutoResponseModel> GetResponse(CategoriaDeProduto categoria)
        {
            return new CategoriaDeProdutoResponseModel(categoria.Id, categoria.Nome, categoria.FornecedorId, categoria.Deleted);
        }

        public async Task<IEnumerable<CategoriaDeProdutoResponseModel>> GetAll()
        {
            var produtos = await _produtoRepository.GetAll();

            return produtos.Select(p => new CategoriaDeProdutoResponseModel(p.Id, p.Nome, p.FornecedorId, p.Deleted));
        }

        public async Task<CategoriaDeProdutoResponseModel> GetById(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            return await GetResponse(produto);
        }

        public async Task<CategoriaDeProdutoResponseModel> Create(CategoriaDeProdutoRequestModel produtoRequestModel)
        {
            var produto = new CategoriaDeProduto(produtoRequestModel.Nome, produtoRequestModel.FornecedorId);

            produto.Validate();

            await _produtoRepository.Create(produto);

            return await GetResponse(produto);
        }

        public async Task<CategoriaDeProdutoResponseModel> Update(int id, CategoriaDeProdutoRequestModel produtoRequestModel)
        {
            var produto = await _produtoRepository.GetById(id);

            produto.Update(produtoRequestModel.Nome);

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