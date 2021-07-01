using System.Collections.Generic;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Postagem : BaseInstaDev, IPostagem
    {
        public int IdPostagem { get; set; }

        public int IdUsuario { get; set; }

        public string Conteudo { get; set; }

        public string Imagem { get; set; }

        public List<Comentario> ListaComentario;

        private const string CAMINHO = "DataBase/Postagem.csv";

        public Postagem()
        {
            CriarPastaArquivo(CAMINHO);
        }


        public void Cadastrar()
        {
            throw new System.NotImplementedException();
        }

        public List<Postagem> ListarPosts()
        {
            throw new System.NotImplementedException();
        }
    }
}