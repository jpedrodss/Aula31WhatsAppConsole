using System;

namespace Aula31WhatsappConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            Contato c1    = new Contato("João", "+55 11 9 9839-3266");
            Contato c2    = new Contato("Pedro", "+55 11 9 9649-6876");
            Contato c3    = new Contato("Irmão", "+55 11 9 4548-2317");
            Mensagem msg  = new Mensagem();

            agenda.Cadastrar(c2);

            // agenda.Excluir("Pedro");

            agenda.Listar();
        }
    }
}
