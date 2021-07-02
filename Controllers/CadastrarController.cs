using InstaDev_Grupo1.Interfaces;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IActionResult Cadastrar(IFormCollection form)
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

            usuarioModel.Cadastrar(novoUsuario);
            ViewBag.Usuarios = (usuarioModel);

            return LocalRedirect("~/Feed/Listar");
            // return LocalRedirect("~/Usuario/Listar");
        }


    }
}