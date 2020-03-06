using BLL.Interfaces;
using DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Impl
{
    public class PedidoService : AbstractValidator<PedidoDTO>, IPedidoService
    {
        public async Task<List<PedidoDTO>> GetRestaurantes()
        {
            throw new NotImplementedException();
        }

        public async Task Insert(PedidoDTO pedido)
        {
            if (string.IsNullOrWhiteSpace(pedido.))
            {
                
            }
            else
            {
                pedido.Produto = pedido.Produto.Trim();

            }
        }
    }
}
