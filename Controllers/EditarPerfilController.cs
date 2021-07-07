using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    
    [Route("EditarPerfil")]
    public class EditarPerfil : Controller
    {

       Usuario usuarioModel = new Usuario();

            [Route("Listar")]
            public IActionResult Index(){
              ViewBag.Usuario = usuarioModel.MostrarDados (int.Parse(HttpContext.Session.GetString("_UserId")));

             return View();
           }

       
    }
}