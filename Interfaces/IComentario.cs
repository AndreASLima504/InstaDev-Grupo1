using System.Collections.Generic;
using InstaDev_Grupo1.Models;

namespace InstaDev_Grupo1.Interfaces
{
    public interface IComentario
    {
         void CadastrarComentario(int IdPostagem, int Idusuario);

         void DeletarComentario(int IdPostagem, int Idusuario);

        List<Comentario> ListarComentarios();
    }
}