using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAO.Repositories.ClienteRepository
{
    public class UserRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UserRepository(MainContext context) : base(context)
        {
        }

        override public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public override async Task Create(Usuario entity)
        {
            if (await VerifyUserLoginAlredyExists(entity))
            {
                throw new Exception("Unique key constraint error: Login");
            }
            await base._dbSet.AddAsync(entity);
            return;
        }

        public override async Task Update(Usuario entity)
        {
            if (await VerifyUserLoginAlredyExists(entity))
            {
                throw new Exception("Unique key constraint error: Login");
            }
            _dbSet.Update(entity);
        }

        public async Task<Usuario> GetByLogin(string login)
        {
            Usuario user = await Query().SingleOrDefaultAsync(u => u.Login == login && !u.IsDeleted);
            return user;
        }

        public async Task<bool> VerifyUserLoginAlredyExists(Usuario user)
        {
            return await _dbSet.AnyAsync(u => u.Login == user.Login && !u.IsDeleted && u.Id != user.Id);
        }
    }
}