using System.Collections.Generic;
using InstaDev_Grupo1.Models;

namespace InstaDev_Grupo1.Interfaces
{
    public interface IPostagem
    {
         void Cadastrar(Postagem p);

         List<Postagem> ListarPosts();

    }
}