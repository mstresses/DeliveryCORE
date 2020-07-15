using DAO.Context;
using DTO;
using DTO.Interfaces;
using DTO.Utils;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAO.Repositories.ClienteRepository
{
    public class UsuarioRepository : GenericRepository<User>, IUsuarioRepository
    {
        private readonly ILogger _logger;

        public UsuarioRepository(DeliveryContext context, ILogger logger) : base(context, logger)
        {
            _logger = logger;
        }

        override public async Task Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogUnexpectedError(ex);
                throw new Exception("unexpected error");
            }
        }

        public override async Task Create(User entity)
        {
            try
            {
                if (await VerifyUserLoginAlredyExists(entity))
                {
                    throw new UniqueKeyConstraintException("unique key constraint error: Login");
                }
                await base._dbSet.AddAsync(entity);
                return;
            }
            catch (UniqueKeyConstraintException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogUnexpectedError(ex);
                throw ex;
            }
        }

        public override async Task Update(User entity)
        {
            try
            {
                if (await VerifyUserLoginAlredyExists(entity))
                {
                    throw new UniqueKeyConstraintException("unique key constraint error: Login");
                }
                _dbSet.Update(entity);
            }
            catch (UniqueKeyConstraintException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _logger.LogUnexpectedError(ex);
                throw ex;
            }
        }

        public async Task<User> GetByLogin(string login)
        {
            User usuario = await Query().SingleOrDefaultAsync(u => u.Login == login && !u.Deleted);
            return usuario;
        }

        public async Task<bool> VerifyUserLoginAlredyExists(User usuario)
        {
            return await _dbSet.AnyAsync(u => u.Login == usuario.Login && !u.Deleted && u.Id != usuario.Id);
        }

        Task<User> IUsuarioRepository.GetByLogin(string login)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> VerifyUserLoginAlredyExists(User usuario)
        {
            throw new System.NotImplementedException();
        }
    }
}