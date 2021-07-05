using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Postagem : BaseInstaDev, IPostagem
    {
        public int IdPostagem { get; set; }

        public int IdUsuario { get; set; }

        public string Conteudo { get; set; }

        public string Imagem { get; set; }

        

        private const string CAMINHO = "DataBase/Postagem.csv";

        public Postagem()
        {
            CriarPastaEArquivo(CAMINHO);
        }

         private string Preparar(Postagem p)
        {
            return $"{p.IdPostagem};{p.IdUsuario};{p.Conteudo}; {p.Imagem}";
        }

        public void Cadastrar(Postagem p)
        {
            string[] linha = {Preparar(p)};
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Postagem> ListarPosts()
        {
           List<Postagem> ListaPostagens= new List<Postagem>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] CadaLinha = item.Split(";");
                Postagem post = new Postagem();

                post.IdPostagem = Int32.Parse(CadaLinha[0]);
                post.IdUsuario = Int32.Parse(CadaLinha[1]);
                post.Conteudo = CadaLinha[2];
                post.Imagem = CadaLinha[3];

                ListaPostagens.Add(post);
            }

            return ListaPostagens;
        }

    }
}