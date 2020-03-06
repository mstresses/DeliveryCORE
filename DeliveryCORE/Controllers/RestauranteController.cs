using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Impl;
using BLL.Remote;
using DeliveryCORE.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryCORE.Controllers
{
    public class RestauranteController : Controller
    {
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
            var configuration = new MapperConfiguration(cfg => {cfg.CreateMap<RestauranteInsertViewModel, RestauranteDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            RestauranteDTO restaurante = mapper.Map<RestauranteDTO>(restauranteViewModel);

            RestauranteService svc = new RestauranteService();
            try
            {
                await svc.(restaurante);
                return RedirectToAction("Index", "Restaurante");
            }
            //catch (NecoException ex)
            //{
            //    ViewBag.Errors = ex.Errors;
            //}
            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult PesquisaCEP(string cep)
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
            //return Json(obj, JsonRequestBehavior.AllowGet);
        }
    }
}