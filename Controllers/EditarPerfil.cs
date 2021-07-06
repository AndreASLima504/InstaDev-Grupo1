using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    
    [Route("EditarPerfil")]
    public class EditarPerfil : Controller
    {

        [Route("Index")]
       public IActionResult Index() {

           return View();
       }
    }
}