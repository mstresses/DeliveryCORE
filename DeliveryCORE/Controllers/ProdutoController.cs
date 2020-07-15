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
    public class ProdutoController : Controller
    {
        private IRestauranteService _restauranteService;
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService, IRestauranteService restauranteService)
        {
            this._produtoService = produtoService;
            this._restauranteService = restauranteService;
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Restaurante, RestauranteSimpleResultSet>().ForMember(c => c.Nome, opts => opts.MapFrom(c => c.NomeFantasia)); });
            IMapper mapper = configuration.CreateMapper();
            List<Restaurante> listRestaurantes = await _restauranteService.GetRestaurantes();
            List<RestauranteSimpleResultSet> restaurantes = mapper.Map<List<RestauranteSimpleResultSet>>(listRestaurantes);
            ViewBag.Restaurantes = restaurantes;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ProdutoInsertViewModel produtoViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<ProdutoInsertViewModel, Produto>(); });
            IMapper mapper = configuration.CreateMapper();
            Produto produto = mapper.Map<Produto>(produtoViewModel);

            try
            {
                await _produtoService.Insert(produto);
                return RedirectToAction("Index", "Produto");
            }
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }

        public async Task<IActionResult> Index()
        {
            List<Produto> produtos = await _produtoService.GetProdutos();

            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Produto, ProdutoQueryViewModel>(); });
            IMapper mapper = configuration.CreateMapper();
            List<ProdutoQueryViewModel> produtoViewModel = mapper.Map<List<ProdutoQueryViewModel>>(produtos);

            ViewBag.Produtos = produtoViewModel;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetProdutosRestaurante(int id)
        {
            List<Produto> produtos = await _produtoService.GetProductsByRestaurant(id);
            return Json(produtos);
        }
    }
}