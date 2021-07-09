using System;
using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Comentario : BaseInstaDev, IComentario
    {
        public int IdComentario { get; set; }

        public int IdUsuario { get; set; }

        public int IdPostagem { get; set; }

        public string Conteudo { get; set; }

        public List<Comentario> ListaComentario;

        private const string CAMINHO = "DataBase/Comentario.csv";



        public Comentario()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string Preparar(Comentario c)
        {
            return $"{c.IdComentario}; {c.IdUsuario}; {c.IdPostagem}; {c.Conteudo}; ";
        }


        public void CadastrarComentario(Comentario c)
        {
            string[] linha = { Preparar(c) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Comentario> ListarComentarios()
        {
            List<Comentario> ListaComentarios = new List<Comentario>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {
                string[] CadaLinha = item.Split(";");
                Comentario coment = new Comentario();

                coment.IdComentario = Int32.Parse(CadaLinha[0]);
                coment.IdUsuario = Int32.Parse(CadaLinha[1]);
                coment.IdPostagem = Int32.Parse(CadaLinha[2]);
                coment.Conteudo = CadaLinha[3];

                ListaComentarios.Add(coment);
            }

            return ListaComentarios;
        
        }

        public void DeletarComentario(Comentario c)
        {
            throw new NotImplementedException();
        }
    }
    }
