using Microsoft.AspNetCore.Http;

namespace InstaDev_Grupo1.Interfaces
{
    public interface ICadastrar
    {
         
        void Criar (IFormCollection form);
        
        void Excluir(int id);
        
    }
}