using System;
using System.Globalization;
using System.IO;

namespace ExercicioFixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Proposta de exercicio:
            // Criar um arquivo csv com os dados "produto, valor, quantidade"
            // Criar um outro arquivo a partir do primeiro em uma nova pasta
            // Este outro arquivo deve conter "produto, valor total"
            try
            {
                // Local da pasta principal
                string principalFolderPath = @"C:\Users\Vini\AulaArquivos";

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

                // Criar a subpasta
                string subFolderPath = principalFolderPath + @"\out";
                Directory.CreateDirectory(subFolderPath);

                // Criar o segundo arquivo
                string secFilePath = subFolderPath + @"\summary.csv";
                FileInfo secondFile = new(secFilePath);

                string[] lines = File.ReadAllLines(principalFilePath);

                using (StreamWriter sw = File.AppendText(secFilePath))
                {
                    foreach (string x in lines)
                    {
                        string[] linesSplit = x.Split(",");
                        double valor = double.Parse(linesSplit[1].Trim(), CultureInfo.InvariantCulture) * double.Parse(linesSplit[2].Trim(), CultureInfo.InvariantCulture);
                        sw.WriteLine(linesSplit[0] + ", " + valor.ToString("F2", CultureInfo.InvariantCulture));
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
