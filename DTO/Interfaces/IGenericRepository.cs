﻿using DTO.Entities.Base;
using System.Threading.Tasks;

namespace DTO
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
        Task Save();
    }
}