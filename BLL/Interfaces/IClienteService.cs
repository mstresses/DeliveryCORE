using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IClienteService
    {
        Task Insert(ClienteDTO restaurante);
        Task<List<ClienteDTO>> GetRestaurantes();
    }
}
