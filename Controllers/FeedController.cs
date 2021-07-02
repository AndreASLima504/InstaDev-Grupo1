using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    [Route ("Feed")]
    public class FeedController : Controller
    {
        Postagem PostagemModel = new Postagem();
        Comentario ComentarioModel = new Comentario();


    }
}