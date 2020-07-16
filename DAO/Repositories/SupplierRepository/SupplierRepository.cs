using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Repositories.ClienteRepository
{
    public class SupplierRepository : GenericRepository<Fornecedor>, IFornecedorRepository
    {
        public SupplierRepository(MainContext context) : base(context)
        {
        }

        public override async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Fornecedor>> GetAll()
        {
            return await Query().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Fornecedor> GetByCnpj(string cnpj)
        {
            return await Query().SingleOrDefaultAsync(s => !s.IsDeleted && s.Cnpj == cnpj);
        }

        public override async Task Create(Fornecedor entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public override async Task Update(Fornecedor entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<bool> VerifyIfSupplierEmailAlredyExists(Fornecedor supplier)
        {
            return await _dbSet.AnyAsync(s => s.Email == supplier.Email && !s.IsDeleted);
        }

        public async Task<bool> VerifyIfSupplierCNPJAlredyExists(Fornecedor supplier)
        {
            return await _dbSet.AnyAsync(s => s.Cnpj == supplier.Cnpj && !s.IsDeleted);
        }

        public async Task<bool> SupplierExists(int id)
        {
            return await _dbSet.AnyAsync(s => s.Id == id && !s.IsDeleted);
        }
    }
}