using System.Collections.Generic;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        Usuario usuarioModel = new Usuario();

        [TempData]
        public string Mensagem { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> usuariosCSV = usuarioModel.LerTodasLinhasCSV("Database/usuario.csv");

            var logado = usuariosCSV.Find(
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            Mensagem = "Dados incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}