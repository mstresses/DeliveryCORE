using AutoMapper;
using BLL.Impl;
using DeliveryCORE.Models.Insert;
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
        public async Task<IActionResult> Cadastrar(ProdutoInsertViewModel produtoViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<ProdutoInsertViewModel, ProdutoDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            ProdutoDTO produto = mapper.Map<ProdutoDTO>(produtoViewModel);

            ProdutoService svc = new ProdutoService();
            try
            {
                await svc.(produto);
                return RedirectToAction("Index", "Produto");
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

        
    }
}
