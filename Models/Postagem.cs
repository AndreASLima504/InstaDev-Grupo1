using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Postagem : BaseInstaDev, IPostagem
    {
        public int IdPostagem { get; set; }

        public string UserName { get; set; }

        public string Conteudo { get; set; }

        public string Imagem { get; set; }



        private const string CAMINHO = "DataBase/Postagem.csv";

        public Postagem()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Postagem p)
        {
            return $"{p.IdPostagem};{p.UserName};{p.Conteudo};{p.Imagem}";
        }

        public void Cadastrar(Postagem p)
        {
            string[] linha = { Preparar(p) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Postagem> ListarPosts()
        {
            List<Postagem> ListaPostagens = new List<Postagem>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] CadaLinha = item.Split(";");
                Postagem post = new Postagem();

                post.IdPostagem = Int32.Parse(CadaLinha[0]);
                post.UserName = CadaLinha[1];
                post.Conteudo = CadaLinha[2];
                post.Imagem = CadaLinha[3];

                ListaPostagens.Add(post);
            }

            return ListaPostagens;
        }

        // Método de Listar Posts do usuário Logado
        public List<Postagem> PostPerfil(string username)
        {

            List<Postagem> Todos_Posts = ListarPosts();

            List<Postagem> Usuario_Posts = new List<Postagem>();

            foreach (var item in Todos_Posts)
            {
                if (item.UserName == username)
                {
                    Usuario_Posts.Add(item);
                }
            }

            return Usuario_Posts;
        }

        
    }
}