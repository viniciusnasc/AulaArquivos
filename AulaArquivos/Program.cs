using System;
using System.IO;

namespace AulaArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Vini\FileExemple.txt";
            string targetPath = @"C:\Users\Vini\FileExemple2.txt";

            try
            {
                FileInfo fileInfo = new(sourcePath); // Instancio um arquivo, no diretorio informado
                fileInfo.CopyTo(targetPath); // Copio o arquivo para o diretorio informado
                string[] lines = File.ReadAllLines(sourcePath); // adiciona uma array com o conteudo das linhas do arquivo
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
