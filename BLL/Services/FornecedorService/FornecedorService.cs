using BLL.Models.Enderecos;
using BLL.Models.Fornecedores;
using DTO;
using DTO.Entities;
using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services.FornecedorService
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
        }

        private Endereco CreateEndereco(EnderecoBaseModel enderecoModel)
        {
            return new Endereco(enderecoModel.Numero, enderecoModel.Rua, enderecoModel.UF, enderecoModel.Pais, enderecoModel.Cidade);
        }

        private async Task<EnderecoResponseModel> GetEnderecoResponse(Endereco endereco)
        {
            return new EnderecoResponseModel(endereco.Numero, endereco.Rua, endereco.UF, endereco.Pais, endereco.Cidade);
        }

        private async Task<FornecedorResponseModel> GetResponse(Fornecedor fornecedor)
        {
            return new FornecedorResponseModel(fornecedor.Id, fornecedor.RazaoSocial, fornecedor.Cnpj, fornecedor.NomeFantasia, 
                                               fornecedor.TelefoneDeContato, fornecedor.EmailDeContato, fornecedor.Deleted);
        }

        private async Task<Fornecedor> GetFornecedorById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID inválido");
            }

            var fornecedor = await _fornecedorRepository.GetById(id);

            if (fornecedor == null)
            {
                throw new Exception("Fornecedor não encontrado.");
            }
            return fornecedor;
        }

        public async Task<IEnumerable<FornecedorResponseModel>> GetAll()
        {
            var fornecedores = await _fornecedorRepository.GetAll();
            
            return fornecedores.Select(fornecedor => new FornecedorResponseModel(fornecedor.Id, fornecedor.RazaoSocial, fornecedor.Cnpj, fornecedor.NomeFantasia,
                                                                                 fornecedor.TelefoneDeContato, fornecedor.EmailDeContato, fornecedor.Deleted));
        }

        public async Task<FornecedorResponseModel> GetById(int id)
        {
            var fornecedor = await GetFornecedorById(id);

            return await GetResponse(fornecedor);
        }

        public async Task<FornecedorResponseModel> Create(FornecedorRequestModel fornecedorRequestModel)
        {
            var endereco = CreateEndereco(fornecedorRequestModel.Endereco);
            var fornecedor = new Fornecedor(fornecedorRequestModel.RazaoSocial, fornecedorRequestModel.Cnpj, fornecedorRequestModel.NomeFantasia, endereco, 
                                            fornecedorRequestModel.TelefoneDeContato, fornecedorRequestModel.EmailDeContato);

            fornecedor.Validate();

            await _fornecedorRepository.Create(fornecedor);

            return await GetResponse(fornecedor);
        }

        public async Task<FornecedorResponseModel> Update(int id, FornecedorRequestModel fornecedorRequestModel)
        {
            var fornecedor = await GetFornecedorById(id);

            var endereco = CreateEndereco(fornecedorRequestModel.Endereco);

            fornecedor.Update(fornecedorRequestModel.NomeFantasia, endereco, 
                              fornecedorRequestModel.TelefoneDeContato, fornecedorRequestModel.EmailDeContato);

            fornecedor.Validate();

            await _fornecedorRepository.Update(fornecedor);

            return await GetResponse(fornecedor);
        }

        public async Task Delete(int id)
        {
            var fornecedor = await GetFornecedorById(id);

            fornecedor.Delete();

            await _fornecedorRepository.Update(fornecedor);
        }
    }
}