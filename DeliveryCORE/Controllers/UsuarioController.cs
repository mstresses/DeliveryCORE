using AutoMapper;
using BLL.Interfaces;
using DAO.Interfaces;
using DeliveryCORE.Models.Insert;
using DTO;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryCORE.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuarioService _usuarioService;
        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Cadastrar(UsuarioInsertViewModel usuarioViewModel)
        {
            
            var configuration = new MapperConfiguration(cfg => {cfg.CreateMap<UsuarioInsertViewModel, UsuarioDTO>(); });
            IMapper mapper = configuration.CreateMapper();
            UsuarioDTO dto = mapper.Map<UsuarioDTO>(usuarioViewModel);
            try
            {
                await _usuarioService.Insert(dto);
                return RedirectToAction("Cadastrar", "Pedido");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(string email, string senha)
        {
            try
            {
                UsuarioDTO usuario = await _usuarioService.Authenticate(email, senha);
                HttpCookie cookie = new HttpCookie();
                cookie.Expires = DateTime.MaxValue;
                Response.Cookies.Append("USERIDENTITY", usuario.ID.ToString());
                //Response.Cookies.Add(cookie);
                return RedirectToAction("Cadastrar", "Pedido");
            }
            catch (Exception ex)
            {
                ViewBag.Erros = ex.Message;
            }
            return View();
        }
    }
}