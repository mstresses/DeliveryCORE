using DAO.Context;
using DTO;
using DTO.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly MainContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(MainContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            TEntity entity = await Query().SingleOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

            if (entity == null)
            {
                throw new ArgumentNullException("Data not found");
            }
            return entity;
        }

        public virtual async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual async Task Delete(int id)
        {
            TEntity entity = await GetById(id);
            entity.SetAsDeleted();
            _dbSet.Update(entity);
        }

        public virtual async Task Save() => await _dbContext.SaveChangesAsync();

        protected IQueryable<TEntity> Query() => _dbSet.AsNoTracking();
    }
}