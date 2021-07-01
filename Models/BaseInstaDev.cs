using System.Collections.Generic;
using System.IO;

namespace InstaDev_Grupo1.Models
{
    public class BaseInstaDev
    {
        public void CriarPastaArquivo(string caminho)
        {
            string pasta = caminho.Split("/")[0];
            string arquivo = caminho.Split("/")[1];

            if (!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }

            if (!File.Exists(caminho))
            {
                File.Create(caminho).Close();
            }
        }

        public List<string> LerLinhasArquivo(string caminho)
        {
            List<string> Listalinhas = new List<string>();
            using (StreamReader file = new StreamReader(caminho))
            {
                string linha;
                while ((linha = file.ReadLine()) != null)
                {
                    Listalinhas.Add(linha);
                }
            }

            return Listalinhas;
        }

        public void Reescrever(string caminho, List<string> linhas)
        {
            using (StreamWriter output = new StreamWriter(caminho))
            {
                foreach (var item in linhas)
                {
                    output.Write($"{item}\n");
                }
            }
        }
    }
}