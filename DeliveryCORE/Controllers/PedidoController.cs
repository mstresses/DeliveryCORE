using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DeliveryCORE.Models.Insert;
using DeliveryCORE.Models.Query;
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
        private IRestauranteService _restauranteService;
        private IProdutoService _produtoService;
        public PedidoController(IPedidoService pedidoService,IRestauranteService restauranteService,IProdutoService produtoService)
        {
            this._pedidoService = pedidoService;
            this._restauranteService = restauranteService;
            this._produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Supplier, RestauranteSimpleResultSet>().ForMember(c=> c.Nome, opts=> opts.MapFrom(c=> c.NomeFantasia)); });
            IMapper mapper = configuration.CreateMapper();
            List<Supplier> listRestaurantes = await _restauranteService.GetRestaurantes();
            List<RestauranteSimpleResultSet> restaurantes = mapper.Map<List<RestauranteSimpleResultSet>>(listRestaurantes);
            ViewBag.Restaurantes = restaurantes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PedidoInsertViewModel pedidoViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<PedidoInsertViewModel, Pedido>(); });
            IMapper mapper = configuration.CreateMapper();
            Pedido pedido = mapper.Map<Pedido>(pedidoViewModel);

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