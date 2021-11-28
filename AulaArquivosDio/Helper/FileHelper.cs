using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaArquivosDio.Helper
{
    public class FileHelper
    {
        public void ListarDiretorios(string path)
        {
            // Com a primeira sobrecarga do metodo GetDirectories pegaremos somente o conteudo do caminho principal.
            // Na terceira sobrecarga com o SearchOption.AllDirectories é informado também o conteúdo dentro das pastas.
            string[] retornoCaminho = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);

            foreach (var retorno in retornoCaminho)
            {
                Console.WriteLine(retorno);
            }

            // Aparentemente funciona da mesma forma que o GetDirectory, porém retorna um IEnumerable<string> ao inves de uma string[]
            // Também funciona com a terceira sobrecarga, para listar as pastas filhas
            IEnumerable<string> folder = Directory.EnumerateDirectories(path);
            Console.WriteLine("FOLDERS: ");
            foreach (string s in folder)
            {
                Console.WriteLine(s);
            }
        }

        public void ListarArquivosDiretorios(string path)
        {
            // A diferença dos dois metodos segue a mesma lógica que o Listar Diretorios
            var retornoArquivos = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (var retorno in retornoArquivos)
            {
                Console.WriteLine(retorno);
            }

            // O asterisco funciona da mesma maneira que no SQL, servindo de filtro de nome para as pesquisas
            var files = Directory.EnumerateFiles(path, "*1*", SearchOption.AllDirectories);
            Console.WriteLine("Files: ");
            foreach (string s in files)
            {
                Console.WriteLine(s);
            }
        }

        public void CriarDiretorio(string path)
        {
            var retorno = Directory.CreateDirectory(path);
            Console.WriteLine(retorno.FullName);
        }

        // Tomar cuidado com esse metodo, pois os diretorios/arquivos que foram apagados não são recuperáveis
        public void ApagarDiretorio(string path, bool apagarArquivos)
        {
            // Dessa forma, somente é excluido o diretorio caso ele esteja vazio. Caso não esteja vazio, gera exceção
            //Directory.Delete(path);

            // Apaga o diretorio junto com todos arquivos ali dentro, desde que o bool seja true, caso seja false, gera exceção
            Directory.Delete(path, apagarArquivos);
        }

        // Utilizar somente se for arquivo pequeno
        public void CriarArquivoTexto(string path, string conteudo)
        {
            // Caso já exista um arquivo com o nome informado na path, ele será sobrescrito, cuidado para não perder informações
            // File.WriteAllText(path, conteudo);

            // Utilizando o metodo Exists ele previne que não sobrescreva o arquivo
            if (!File.Exists(path))
                File.WriteAllText(path, conteudo);

            // Também é possivel criar arquivo a partir do fileinfo: 
            FileInfo file = new(path);
        }

        // Utilizar para arquivos grandes
        public void CriarArquivoTextoStream(string path, List<string> conteudo)
        {
            using (StreamWriter stream = File.CreateText(path))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }
        }

        public void AdicionarTexto(string path, string conteudo)
        {
            // Se o arquivo existir, coloca o conteudo no final do arquivo, caso nao exista, cria um novo arquivo
            File.AppendAllText(path, conteudo);
        }

        public void AdicionarTextoStream(string path, List<string> conteudo)
        {
            using (StreamWriter stream = File.AppendText(path))
            {
                foreach (var linha in conteudo)
                {
                    stream.WriteLine(linha);
                }
            }
        }

        public void LerArquivo(string path)
        {
            var texto = File.ReadAllLines(path);
            foreach(var line in texto)
            {
                Console.WriteLine(line);
            }
        }

        public void LerArquivoStream(string path)
        {
            string linha = string.Empty;

            using (StreamReader stream = File.OpenText(path))
            {
                while ((linha = stream.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }

        public void MoverArquivo(string path, string newPath)
        {
            // Se necessario, no newPath posso dar outro nome para o arquivo
            // Caso já exista um arquivo com o mesmo nome que o especificado, irá gerar uma excessão
            // A segunda sobrecarga deixa você sobrescrever caso exista um arquivo com o mesmo nome
            File.Move(path, newPath);
        }

        public void CopiarArquivo(string path, string newPath)
        {
            // Assim como o move, é possivel fazer o metodo com a primeira sobrecarga, impedindo a sobrescrita e grando excessão caso já exista arquivo com o mesmo nome
            File.Copy(path, newPath, true);
        }

        public void DeletarArquivo(string path)
        {
            // Assim como o deletar diretorio, se realizar esse metodo nao é possivel recuperar o arquivo
            File.Delete(path);
        }
    }
}
