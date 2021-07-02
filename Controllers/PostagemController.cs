using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaDev_Grupo1.Controllers
{
    [Route("Postagem")]
    public class PostagemController : Controller
    {
        Postagem PostagemModel = new Postagem();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = PostagemModel.ListarPosts();
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
            // NovaPostagem.IdUsuario = ;
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

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", folder, file.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                NovaPostagem.Imagem = file.FileName;
            }
            else
            {
                NovaPostagem.Imagem = "";
            }

            PostagemModel.Cadastrar(NovaPostagem);

            ViewBag.Postagens = PostagemModel.ListarPosts();

            return LocalRedirect("~/Postagem/Listar");
        }


    }
}