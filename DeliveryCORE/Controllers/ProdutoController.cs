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
    public class ProdutoController : Controller
    {
        private IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            this._produtoService = produtoService;
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

        public IActionResult Index()
        {
            return View();
        }
    }
}