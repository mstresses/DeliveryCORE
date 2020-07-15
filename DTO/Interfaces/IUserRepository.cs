using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByLogin(string login);
        Task<bool> VerifyUserLoginAlredyExists(User user);
    }
}