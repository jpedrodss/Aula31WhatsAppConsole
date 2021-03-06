using System;

namespace Aula31WhatsappConsole
{
    public class Mensagem
    {
        public string Texto { get; set; }
        public Contato Destinatario;
        /// <summary>
        /// Envia mensagem para um contato
        /// </summary>
        /// <param name="c">contato</param>
        public void Enviar(Contato c){
            Console.WriteLine($"Qual mensagem deseja enviar para {c.Nome}?");
            Texto = Console.ReadLine();

            System.Console.WriteLine($"Mensagem '{Texto}' enviada para {c.Nome}."); 
        }
    }
}