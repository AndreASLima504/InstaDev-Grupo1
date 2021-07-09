using System.Collections.Generic;
using System;
using System.IO;
using InstaDev_Grupo1.Interfaces;

namespace InstaDev_Grupo1.Models
{
    public class Usuario : BaseInstaDev, IUsuario
    {
        public string Nome { get; set; }

        public int IdUsuario { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Foto { get; set; }

        private const string CAMINHO = "Database/usuario.csv";
        public Usuario()
        {
            CriarPastaEArquivo(CAMINHO);
        }

        private string PrepararLinha(Usuario u)
        {
            return $"{u.IdUsuario};{u.Nome};{u.UserName};{u.Email};{u.Senha}";
        }

        public void Cadastrar(Usuario u)
        {
            string[] linha = { PrepararLinha(u) };
            File.AppendAllLines(CAMINHO, linha);
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            string[] linhas = File.ReadAllLines(CAMINHO);

            foreach (var item in linhas)
            {

                string[] linha = item.Split(";");
                Usuario novousuario = new Usuario();

                novousuario.IdUsuario = Int32.Parse(linha[0]);
                novousuario.Nome = linha[1];
                novousuario.UserName = linha[2];
                novousuario.Email = linha[3];
                novousuario.Senha = linha[4];

                usuarios.Add(novousuario);
            }
            return usuarios;
        }
        public void Alterar(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == u.IdUsuario.ToString());

            linhas.Add(PrepararLinha(u));
            ReescreverCSV(CAMINHO, linhas);
        }


        public void Deletar(Usuario u)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == IdUsuario.ToString());

            ReescreverCSV(CAMINHO, linhas);
        }

        public Usuario MostrarDados(int IdUsuario)
        {
            List<Usuario> usuarios = ListarUsuarios();
            Usuario UsuarioProcurado = usuarios.Find(x => x.IdUsuario == IdUsuario);
          

            return UsuarioProcurado;
        }

    
    }
}