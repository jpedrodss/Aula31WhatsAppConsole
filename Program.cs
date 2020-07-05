using System;
using System.Collections.Generic;

namespace Aula31WhatsappConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda agenda = new Agenda();
            Contato c1    = new Contato();
            c1.Nome = "João";
            c1.Telefone = "+55 11 9 9839-3266";
            Mensagem msg  = new Mensagem();

            agenda.Cadastrar(c1);

            // agenda.Excluir("Pedro");

            List<Contato> lista = agenda.Listar();

            foreach (Contato item in lista){
                System.Console.WriteLine($"Nome: {item.Nome} - Telefone: {item.Telefone}");
            }

        }
    }
}
