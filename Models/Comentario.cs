using System.Collections.Generic;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Comentario : IComentario
    {
        public int IdComentario { get; set; }

        public int IdUsuario { get; set; }

        public int IdPostagem { get; set; }

        public string Conteudo { get; set; }

        public List<Comentario> ListaComentario;

        public void CadastrarComentario(int IdPostagem, int Idusuario)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarComentario(int IdPostagem, int Idusuario)
        {
            throw new System.NotImplementedException();
        }

        public List<Comentario> ListarComentarios()
        {
            throw new System.NotImplementedException();
        }
    }
}