using System;
using System.IO;

namespace FileStream_StreamReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Vini\FileExemple.txt";

            // Para utilizar o StreamReader é necessario instanciar um FileStream
            // Utilizando o comando "File.OpenText(path)" para o objeto StreamReader, retira a necessidade de precisar instanciar um FS
            // Ambos necessitam ser fechado apos a utilização
            // Utilizando o using, ele irá fechar automaticamente os dois objetos

            try
            {
                using (FileStream fs = new(path, FileMode.Open))
                {
                    using (StreamReader sr = new(fs))
                    {
                        while (!sr.EndOfStream) // Comando para ir ate o final do arquivo
                        {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}
