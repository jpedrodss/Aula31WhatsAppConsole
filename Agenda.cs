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

        public void ReescreverCSV(List<string> linhas){
            using (StreamWriter output = new StreamWriter(PATH)){
                foreach (string ln in linhas){
                    output.Write(ln + "\n");
                }
            }
        }
        public void RemoverLinhas(List<string> linhas, string _termo){
            using (StreamReader arquivo = new StreamReader(PATH)){
                string linha;

                while ((linha = arquivo.ReadLine()) != null){
                    linhas.Add(linha);
                }
                linhas.RemoveAll(z => z.Contains(_termo));
            }
        }
        public string Separar(string dado)
        {
            return dado.Split('=')[1];
        }
        public void Cadastrar(Contato c){
            var linha = new string[] { PrepararLinha(c) };
            File.AppendAllLines(PATH, linha);
        }

        public void Excluir(string _termo){
            List<string> linhas = new List<string>();

            RemoverLinhas(linhas, _termo);

            ReescreverCSV(linhas);
        }

        public void Listar(){
            
            // Não consegui achar uma maneira que esse método funcionasse.

        }

        private string PrepararLinha(Contato c){
            return $"Nome={c.Nome};Telefone={c.Telefone}";
        }
    }
}