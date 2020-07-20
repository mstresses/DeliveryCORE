using DAO.Context;
using DAO.Repositories.GenericRepository;
using DTO;
using DTO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DAO.Repositories.UsuarioRepository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(MainContext context) : base(context)
        {
        }

        //public override async Task Create(Usuario entity)
        //{
        //    if (await VerifyUserLoginAlredyExists(entity))
        //    {
        //        throw new Exception("Unique key constraint error: Login");
        //    }
        //    await base._dbSet.AddAsync(entity);
        //    return;
        //}

        //public override async Task Update(Usuario entity)
        //{
        //    if (await VerifyUserLoginAlredyExists(entity))
        //    {
        //        throw new Exception("Unique key constraint error: Login");
        //    }
        //    _dbSet.Update(entity);
        //}

        public async Task<Usuario> GetByLogin(string login)
        {
            Usuario user = await Query().SingleOrDefaultAsync(u => u.Login == login && !u.Deleted);
            return user;
        }

        public async Task<bool> VerifyUserLoginAlredyExists(Usuario user)
        {
            return await _dbSet.AnyAsync(u => u.Login == user.Login && !u.Deleted && u.Id != user.Id);
        }

        public Task<bool> VerificaSeUsuarioJaExiste(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}