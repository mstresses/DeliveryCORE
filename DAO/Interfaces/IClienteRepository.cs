﻿using DTO;
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
        Task<ClienteDTO> Authenticate(string email, string senha);
    }
}