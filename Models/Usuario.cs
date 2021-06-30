using System.Collections.Generic;
using System.IO;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Usuario : IUsuario
    {
        public string Nome { get; set; }

        public string UserName { get; set; }

        private string Email { get; set; }

        private string Senha { get; set; }

        public string Foto { get; set; }

        public void Cadastrar(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void Logar(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void Alterar(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(Usuario u)
        {
            throw new System.NotImplementedException();
        }

        public List<Usuario> MostrarDados()
        {
            throw new System.NotImplementedException();
        }
    }
}