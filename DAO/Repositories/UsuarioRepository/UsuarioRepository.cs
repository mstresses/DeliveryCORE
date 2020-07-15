using DAO.Context;
using DTO;
using DTO.Interfaces;
using HBSIS.Padawan.Produtos.Infra.Repository.GenericRepository;

namespace DAO.Repositories.ClienteRepository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DeliveryContext dbContext) : base(dbContext)
        {
        }
    }
}