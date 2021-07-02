using InstaDev_Grupo1.Interfaces;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InstaDev_Grupo1.Controllers
{
    public class CadastrarController : Controller
    {

        Usuario usuarioModel = new Usuario();

         [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = usuarioModel.ListarUsuarios();
            return View();
        }

         [Route("Cadastrar")]
        public IActionResult Cadastrar (IFormCollection form)
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.IdUsuario = Int32.Parse(form["IdUsuario"]);
            novoUsuario.Nome = form["Nome"];
            novoUsuario.Email = form["Email"];
            novoUsuario.Senha = form["Senha"];

            usuarioModel.Cadastrar(novoUsuario);
            ViewBag.Usuarios = (usuarioModel);

            return LocalRedirect ("~/Usuario/Listar");
        }

        
    }
}