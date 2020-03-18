using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Interfaces
{
    public interface IClienteRepository
    {
        Task Insert(ClienteDTO cliente);
        Task Update(ClienteDTO cliente);
        Task Delete(ClienteDTO cliente);
        Task<List<ClienteDTO>> GetClientes();
    }
}