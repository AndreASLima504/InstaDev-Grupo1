using System.Collections.Generic;
using InstaDev_Grupo1.Models;

namespace InstaDev_Grupo1.Interfaces
{
    public interface IPostagem
    {
         void Cadastrar();

         List<Postagem> ListarPosts();

         void LinkPerfil();

         List<Usuario> ListarUsuarios();
    }
}