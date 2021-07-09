using System.Collections.Generic;
using InstaDev_Grupo1.Models;

namespace InstaDev_Grupo1.Interfaces
{
    public interface IUsuario
    {
        void Cadastrar(Usuario u);

        void Alterar(Usuario u);

        void Deletar(Usuario u);

        Usuario MostrarDados(int IdUsuario);

        List<Usuario> ListarUsuarios();

    }
}