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
    public class ClienteController:Controller
    {

        private IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this._clienteService = clienteService;
        }
        
        [HttpGet]

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Cadastrar(ClienteInsertViewModel clienteViewModel)
        {
            var configuration = new MapperConfiguration(cfg => { cfg.CreateMap<ClienteInsertViewModel, ClienteDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            ClienteDTO cliente = mapper.Map<ClienteDTO>(clienteViewModel);

            try
            {
                await _clienteService.Insert(cliente);
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
    }
