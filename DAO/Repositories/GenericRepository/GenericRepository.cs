using DAO.Context;
using DTO;
using DTO.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DAO.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        private void VerificaSeEntidadeEhNula(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.FromResult(Query());
        }

        public async Task<TEntity> GetById(int id)
        {
            if (id <= 0)
            {
                throw new Exception("ID inválido.");
            }

            return await Query().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(TEntity entity)
        {
            VerificaSeEntidadeEhNula(entity);

            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            VerificaSeEntidadeEhNula(entity);

            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);

            VerificaSeEntidadeEhNula(entity);

            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        protected IQueryable<TEntity> Query() => _dbSet.AsNoTracking();
    }
}