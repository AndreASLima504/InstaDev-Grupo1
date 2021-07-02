using System;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : Controller
    {


        Usuario usuarioModel = new Usuario();

        [Route("Listar")]
        public IActionResult Index()
        {
           ViewBag.Usuarios = usuarioModel.ListarUsuarios();
            return View();
        }

       
    }
}