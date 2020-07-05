using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Aula31WhatsappConsole
{
    public class Agenda : IAgenda
    {
        public List<Contato> Contatos;
        private const string PATH = "Database/Agenda.CSV";

        public Agenda(){
            if (!File.Exists(PATH)){
                Directory.CreateDirectory("Database");
                File.Create(PATH).Close();
            }
        }
        /// <summary>
        /// Apaga linhas no CSV
        /// </summary>
        /// <param name="linhas">linha do csv</param>
        public void ReescreverCSV(List<string> linhas){
            using (StreamWriter output = new StreamWriter(PATH)){
                foreach (string ln in linhas){
                    output.Write(ln + "\n");
                }
            }
        }
        /// <summary>
        /// Lê as linhas do CSV para remover
        /// </summary>
        /// <param name="linhas">linha do csv</param>
        /// <param name="_termo">termo será utilizado para apagar um contato da lista (Nome ou Telefone)</param>
        public void RemoverLinhas(List<string> linhas, string _termo){
            using (StreamReader arquivo = new StreamReader(PATH)){
                string linha;

                while ((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo));
            }
        }

        /// <summary>
        /// Cadastra um número na lista de contatos
        /// </summary>
        /// <param name="c">contato</param>
        public void Cadastrar(Contato c){
            var linha = new string[] { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// Exclue um contato da lista csv
        /// </summary>
        /// <param name="_termo">termo será utilizado para apagar um contato da lista (Nome ou Telefone)</param>
        public void Excluir(string _termo){
            List<string> linhas = new List<string>();

            RemoverLinhas(linhas, _termo);

            ReescreverCSV(linhas);
        }

        public void Listar(){
            
            // Não consegui achar uma maneira que esse método funcionasse.

        }
        /// <summary>
        /// Usado para escrever a linha
        /// </summary>
        /// <param name="c">contato</param>
        /// <returns>Linha no CSV com as informações</returns>
        private string PrepararLinha(Contato c){
            return $"Nome={c.Nome};Telefone={c.Telefone}";
        }
    }
}