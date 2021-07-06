using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    [Route("Feed")]
    public class FeedController : Controller
    {
        Postagem PostagemModel = new Postagem();

        Usuario UsuarioModel = new Usuario();

        Comentario ComentarioModel = new Comentario();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Usuarios = UsuarioModel.ListarUsuarios();
            ViewBag.Postagens = PostagemModel.ListarPosts();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {

            Postagem NovaPostagem = new Postagem();
            Postagem PostagemEncontrada = new Postagem();

            do
            {
                Random Id = new Random();
                List<Postagem> ListaPostagem = PostagemModel.ListarPosts();
                int IdNew = Id.Next(500000);


                PostagemEncontrada = ListaPostagem.Find(item => item.IdPostagem == IdNew);

                if (PostagemEncontrada == null)
                {
                    NovaPostagem.IdPostagem = IdNew;
                }

            } while (PostagemEncontrada != null);


            // id Usuario
            ViewBag.Usuarios = UsuarioModel.MostrarDados (int.Parse(HttpContext.Session.GetString("_UserId")));
            // NovaPostagem.IdUsuario = UsuarioModel.IdUsuario;
            NovaPostagem.Conteudo = form["Conteudo"];
            NovaPostagem.Imagem = form["Imagem"];

            if (form.Files.Count > 0)
            {
                // uplopad início

                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Postagens");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);

                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                NovaPostagem.Imagem = file.FileName;
            }
            else
            {
                NovaPostagem.Imagem = "padraoFeed.png";
            }

            PostagemModel.Cadastrar(NovaPostagem);

            ViewBag.Postagens = PostagemModel.ListarPosts();

            return LocalRedirect("~/Feed/Listar");
        }



    }
}