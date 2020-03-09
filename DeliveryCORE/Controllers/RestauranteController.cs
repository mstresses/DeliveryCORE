using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using BLL.Remote;
using DeliveryCORE.Models;
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

        public IActionResult Index()
        {
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
            var configuration = new MapperConfiguration(cfg => {cfg.CreateMap<RestauranteInsertViewModel, ProdutoDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            RestauranteDTO restaurante = mapper.Map<RestauranteDTO>(restauranteViewModel);

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

        [HttpPost]
        public IActionResult PesquisaCEP(string cep)
        {
            cep = cep.Replace("-", "");
            CepRemoteService cepSvc = new CepRemoteService(cep);
            var obj = new
            {
                Bairro = cepSvc.Bairro,
                Rua = cepSvc.Logradouro,
                UF = cepSvc.UF,
                Cidade = cepSvc.Cidade
            };
            return Json(obj);
        }
    }
}