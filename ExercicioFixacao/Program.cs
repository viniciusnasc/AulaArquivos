using System;
using System.IO;

namespace ExercicioFixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Local da pasta principal
            string principalPastPath = @"C:\Users\Vini\AulaArquivos";

            // Criar o arquivo principal
            string principalFilePath = @"C:\Users\Vini\AulaArquivos\principal.csv";
            FileInfo principalFile = new(principalFilePath);

            using (StreamWriter sw = File.AppendText(principalFilePath))
            {
                sw.WriteLine("TV LED, 1290.99, 1");
                sw.WriteLine("Video Game Chair, 350.50, 3");
                sw.WriteLine("Iphone X, 900.00, 2");
                sw.WriteLine("Samsung Galaxy 9, 850.00, 2");
            }
        }
    }
}
