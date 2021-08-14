using System;
using System.IO;

namespace Stream_Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourcePath = @"C:\Users\Vini\FileExemple.txt";
            string targetPath = @"C:\Users\Vini\FileExemple2.txt";

            try
            {
                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(targetPath))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line.ToUpper());
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
