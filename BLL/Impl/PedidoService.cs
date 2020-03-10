﻿using BLL.Interfaces;
using BLL.Validators;
using Common;
using DAO;
using DAO.Interfaces;
using DTO;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class PedidoService : PedidoValidator, IPedidoService
    {
        List<string> Erros = new List<string>();
        private IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this._pedidoRepository = pedidoRepository;
        }

        public async Task Insert(PedidoDTO pedido)
        {
            

            try
            {
                await _pedidoRepository.Insert(pedido);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.InnerException.Message.Contains("UQ"))
                {
                    throw new Exception();
                }
                File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                throw new Exception("Erro no banco de dados, contate o administrador.");
            }
        }

        public async Task<List<PedidoDTO>> GetPedidos()
        {
            return await _pedidoRepository.GetPedidos();
        }
    }
}