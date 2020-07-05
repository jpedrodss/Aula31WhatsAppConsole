using System.Collections.Generic;

namespace Aula31WhatsappConsole
{
    public interface IAgenda
    {
         void Cadastrar(Contato c);
         void Excluir(string _termo);
         void Listar();
    }
}