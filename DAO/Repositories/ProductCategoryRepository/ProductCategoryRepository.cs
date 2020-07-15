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
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public override async Task<ProductCategory> GetById(int id)
        {
            ProductCategory productCategory = await Query().Where(p => p.Id == id && !p.IsDeleted).SingleOrDefaultAsync();
            if (productCategory == null)
            {
                throw new ArgumentNullException("product category not found");
            }
            return productCategory;
        }

        public async Task<int> GetProductCategoryId(ProductCategory productCategory)
        {
            return (await Query().SingleOrDefaultAsync(p => !p.IsDeleted &&
                                                       p.Name == productCategory.Name &&
                                                       p.SupplierId == productCategory.SupplierId)).Id;
        }

        public override async Task Update(ProductCategory productCategory)
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

        public async Task<IEnumerable<ProductCategory>> GetAll()
        {
            return await Query().Where(p => !p.IsDeleted).ToListAsync();
        }

        public async Task Delete(int id)
        {
            ProductCategory productCategory = await GetById(id);
            productCategory.SetAsDeleted();
            _dbContext.Update(productCategory);
        }

        public async Task<bool> VerifyIfProductCategoryAlreadyExistsInSupplier(ProductCategory productCategory)
        {
            return await Query().Where(p => p.SupplierId == productCategory.SupplierId && p.Name == productCategory.Name).AnyAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllIncludingSupplier()
        {
            return await Query().Include(p => p.Supplier).ToListAsync();
        }

        public Task SaveCustomIdentity()
        {
            throw new NotImplementedException();
        }
    }
}