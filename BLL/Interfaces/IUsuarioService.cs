﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUsuarioService
    {
        Task Insert(UsuarioDTO usuario);
        Task<UsuarioDTO> Authenticate(string email, string senha);
    }
}