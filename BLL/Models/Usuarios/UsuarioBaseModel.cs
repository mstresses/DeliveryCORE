﻿namespace BLL.Models.Usuarios
{
    public abstract class UsuarioBaseModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}