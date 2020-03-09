using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DeliveryCORE.Models.Insert;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Controllers
{
    public class PedidoController : Controller
    {
        private IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            this._pedidoService = pedidoService;
        }

        [HttpGet]

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]


        public async Task<IActionResult> Cadastrar(PedidoInsertViewModel pedidoViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<PedidoInsertViewModel, PedidoDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            PedidoDTO pedido = mapper.Map<PedidoDTO>(pedidoViewModel);

            try
            {
                await _pedidoService.Insert(pedido);
                return RedirectToAction("Index", "Pedido");
            }
            
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
