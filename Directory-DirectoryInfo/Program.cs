using System;
using System.Collections.Generic;
using System.IO;

namespace Directory_DirectoryInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Vini\AulaArquivos";

            try
            {
                // Listar pastas
                IEnumerable<string> folder = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS: ");
                foreach(string s in folder)
                {
                    Console.WriteLine(s);
                }

                // Listar arquivos
                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("Files: ");
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }

                // Criar pasta

                Directory.CreateDirectory(path + @"\newfolder");
            }
            catch
            {

            }
        }
    }
}
