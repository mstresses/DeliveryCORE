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
    public class SupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MainContext context) : base(context)
        {
        }

        public override async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Supplier>> GetAll()
        {
            return await Query().Where(s => !s.IsDeleted).ToListAsync();
        }

        public async Task<Supplier> GetByCnpj(string cnpj)
        {
            return await Query().SingleOrDefaultAsync(s => !s.IsDeleted && s.Cnpj == cnpj);
        }

        public override async Task Create(Supplier entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public override async Task Update(Supplier entity)
        {
            _dbSet.Update(entity);
        }

        public async Task<bool> VerifyIfSupplierEmailAlredyExists(Supplier supplier)
        {
            return await _dbSet.AnyAsync(s => s.Email == supplier.Email && !s.IsDeleted);
        }

        public async Task<bool> VerifyIfSupplierCNPJAlredyExists(Supplier supplier)
        {
            return await _dbSet.AnyAsync(s => s.Cnpj == supplier.Cnpj && !s.IsDeleted);
        }

        public async Task<bool> SupplierExists(int id)
        {
            return await _dbSet.AnyAsync(s => s.Id == id && !s.IsDeleted);
        }
    }
}