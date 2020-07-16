using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Repositories.ClienteRepository
{
    public class ProductCategoryRepository : GenericRepository<CategoriaDeProduto>, ICategoriaDeProdutoRepository
    {
        public ProductCategoryRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CategoriaDeProduto> GetById(int id)
        {
            CategoriaDeProduto productCategory = await Query().Where(p => p.Id == id && !p.IsDeleted).SingleOrDefaultAsync();
            if (productCategory == null)
            {
                throw new ArgumentNullException("product category not found");
            }
            return productCategory;
        }

        public async Task<int> GetProductCategoryId(CategoriaDeProduto productCategory)
        {
            return (await Query().SingleOrDefaultAsync(p => !p.IsDeleted &&
                                                       p.Name == productCategory.Name &&
                                                       p.SupplierId == productCategory.SupplierId)).Id;
        }

        public override async Task Update(CategoriaDeProduto productCategory)
        {
            if (await VerifyIfProductCategoryExists(productCategory.Id))
            {
                _dbContext.Update(productCategory);
                return;
            }

            throw new ArgumentNullException("product category not found");
        }

        public async Task<bool> VerifyIfProductCategoryExists(int id)
        {
            return await _dbSet.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<CategoriaDeProduto>> GetAll()
        {
            return await Query().Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task Delete(int id)
        {
            CategoriaDeProduto productCategory = await GetById(id);
            productCategory.SetAsDeleted();
            _dbContext.Update(productCategory);
        }

        public async Task<bool> VerifyIfProductCategoryAlreadyExistsInSupplier(CategoriaDeProduto productCategory)
        {
            return await Query().Where(p => p.SupplierId == productCategory.SupplierId && p.Name == productCategory.Name).AnyAsync();
        }

        public async Task<IEnumerable<CategoriaDeProduto>> GetAllIncludingSupplier()
        {
            return await Query().Include(p => p.Supplier).ToListAsync();
        }

        public Task SaveCustomIdentity()
        {
            throw new NotImplementedException();
        }
    }
}