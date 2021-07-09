using System.Collections.Generic;
using InstaDev_Grupo1.Models;

namespace InstaDev_Grupo1.Interfaces
{
    public interface IComentario
    {
         void CadastrarComentario(Comentario c);

         void DeletarComentario(Comentario c);

        List<Comentario> ListarComentarios();
    }
}