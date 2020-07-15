using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<User>
    {
        Task<User> GetByLogin(string login);
        Task<bool> VerifyUserLoginAlredyExists(User usuario);
    }
}