using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using BLL.Remote;
using DeliveryCORE.Models;
using DeliveryCORE.Models.Query;
using DeliveryCORE.Models.Update;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCORE.Controllers
{
    public class RestauranteController : Controller
    {
        private IRestauranteService _restauranteService;

        public RestauranteController(IRestauranteService restauranteService)
        {
            this._restauranteService = restauranteService;
        }

        public async Task<IActionResult> Index()
        {
            List<Fornecedor> restaurantes = await _restauranteService.GetRestaurantes();

            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Fornecedor, RestauranteSimpleResultSet>().ForMember(c=> c.Nome, opts=> opts.MapFrom(s=> s.NomeFantasia));});
            IMapper mapper = configuration.CreateMapper();
            List<RestauranteSimpleResultSet> restaurantesViewModel = mapper.Map<List<RestauranteSimpleResultSet>>(restaurantes);

            ViewBag.Restaurantes = restaurantesViewModel;
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RestauranteInsertViewModel restauranteViewModel)
        {
            var configuration = new MapperConfiguration(cfg => {cfg.CreateMap<RestauranteInsertViewModel, Fornecedor>(); });
            IMapper mapper = configuration.CreateMapper();
            Fornecedor restaurante = mapper.Map<Fornecedor>(restauranteViewModel);

            try
            {
                await _restauranteService.Insert(restaurante);
                return RedirectToAction("Index", "Restaurante");
            }
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Atualizar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(RestauranteUpdateViewModel updateViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<RestauranteUpdateViewModel, Cliente>(); });
            IMapper mapper = configuration.CreateMapper();
            Fornecedor restaurante = mapper.Map<Fornecedor>(updateViewModel);

            try
            {
                await _restauranteService.Update(restaurante);
                return RedirectToAction("Index", "Restaurante");
            }

            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(Fornecedor restaurante)
        {
            try
            {
                await _restauranteService.Delete(restaurante);
                return RedirectToAction("Index", "Restaurante");
            }

            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }

        //[HttpPost]
        //public IActionResult PesquisaCEP(string cep)
        //{
        //    cep = cep.Replace("-", "");
        //    CepRemoteService cepSvc = new CepRemoteService(cep);
        //    var obj = new
        //    {
        //        Bairro = cepSvc.Bairro,
        //        Rua = cepSvc.Logradouro,
        //        UF = cepSvc.UF,
        //        Cidade = cepSvc.Cidade
        //    };
        //    return Json(obj);
        //}
    }
}