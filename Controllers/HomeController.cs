using System;
using System.Collections.Generic;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstaDev_Grupo1.Controllers
{
    public class HomeController : Controller
    {
        Usuario usuarioModel = new Usuario();
        private readonly ILogger<HomeController> _logger;

        public Usuario UsuarioModel { get => usuarioModel; set => usuarioModel = value; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // ViewBag.UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar (IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();

            Usuario UsuarioEncontrado = new Usuario();

            do
            {
                Random Id = new Random();
                List<Usuario> ListaUsuario = usuarioModel.ListarUsuarios();
                int IdNew = Id.Next(500000);


                UsuarioEncontrado = ListaUsuario.Find(item => item.IdUsuario == IdNew);

                if (UsuarioEncontrado == null)
                {
                    novoUsuario.IdUsuario = IdNew;
                }

            } while (UsuarioEncontrado != null);

            // novoUsuario.IdUsuario = Int32.Parse(form["IdUsuario"]);

            novoUsuario.Nome = form["Nome"];
            novoUsuario.UserName = form["Username"];
            novoUsuario.Email = form["Email"];
            novoUsuario.Senha = form["Senha"];

            UsuarioModel.Cadastrar(novoUsuario);

            return LocalRedirect("~/Login");
        }
    }
}
