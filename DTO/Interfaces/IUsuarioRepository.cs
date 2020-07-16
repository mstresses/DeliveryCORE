using System.Threading.Tasks;

namespace DTO.Interfaces
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByLogin(string login);
        Task<bool> VerificaSeUsuarioJaExiste(Usuario usuario);
    }
}