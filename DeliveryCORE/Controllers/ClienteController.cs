using AutoMapper;
using BLL.Impl;
using BLL.Interfaces;
using DeliveryCORE.Models.Delete;
using DeliveryCORE.Models.Insert;
using DeliveryCORE.Models.Query;
using DeliveryCORE.Models.Update;
using DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Controllers
{
    public class ClienteController : Controller
    {
        private IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = await _clienteService.GetClientes();

            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<Cliente, ClienteQueryViewModel>(); });
            IMapper mapper = configuration.CreateMapper();
            List<ClienteQueryViewModel> clienteViewModel = mapper.Map<List<ClienteQueryViewModel>>(clientes);

            ViewBag.Clientes = clienteViewModel;
            return View();
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(ClienteInsertViewModel clienteViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<ClienteInsertViewModel, Cliente>(); });
            IMapper mapper = configuration.CreateMapper();
            Cliente cliente = mapper.Map<Cliente>(clienteViewModel);

            try
            {
                await _clienteService.Insert(cliente);
                return RedirectToAction("Index", "Cliente");
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
        public async Task<IActionResult> Atualizar(ClienteUpdateViewModel updateViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<ClienteUpdateViewModel, Cliente>(); });
            IMapper mapper = configuration.CreateMapper();
            Cliente cliente = mapper.Map<Cliente>(updateViewModel);

            try
            {
                await _clienteService.Update(cliente);
                return RedirectToAction("Index", "Cliente");
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
        public async Task<IActionResult> Excluir(Cliente cliente)
        {
            try
            {
                await _clienteService.Delete(cliente);
                return RedirectToAction("Index", "Cliente");
            }

            catch (Exception ex)
            {
                ViewBag.ErroGenerico = ex.Message;
            }
            return View();
        }
    }
}