using AulaArquivosDio.Helper;
using System;
using System.Collections.Generic;
using System.IO;

namespace AulaArquivosDio
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper helper = new();
            var path = "C:\\Users\\Vini\\source\\repos\\AulaArquivos\\AulaArquivosDio\\TrabalhandoComArquivos";
            List<string> listaString = new() {"Linha1", "Linha2", "Linha3" };
            List<string> listaContinuacao = new() { "Linha4", "Linha5", "Linha6" };

            // helper.ListarDiretorios(path);
            // helper.ListarArquivosDiretorios(path);

            // Path.Combine é um facilitador para a criação de um caminho, podemos utilizar ele, assim como uma concatenação de string
            // helper.CriarDiretorio(path + "\\pasta teste 3\\subPastaTeste3");
            // helper.CriarDiretorio(Path.Combine(path, "pasta teste 3", "subPastaTeste3"));

            // helper.ApagarDiretorio(Path.Combine(path, "Pasta Teste 2"), false);

             helper.CriarArquivoTexto(Path.Combine(path, "arquivo-teste.csv"), "Vinicius Nascimento - teste de escrita de arquivo");

            // helper.CriarArquivoTextoStream(Path.Combine(path, "arquivo-teste-stream.txt"),listaString);
            // helper.AdicionarTextoStream(Path.Combine(path, "arquivo-teste-stream.txt"), listaContinuacao);
            // helper.AdicionarTexto(Path.Combine(path, "arquivo-teste.txt"), "VINICIUS");

            // helper.LerArquivo(Path.Combine(path, "arquivo-teste.txt"));
            // helper.LerArquivoStream(Path.Combine(path, "arquivo-teste.txt"));

            // helper.MoverArquivo(Path.Combine(path, "arquivo-teste.txt"), Path.Combine(path, "pasta teste 3","arquivo-teste-stream-teste3.txt"));

            // helper.CopiarArquivo(Path.Combine(path, "arquivo-teste.txt"), Path.Combine(path, "pasta teste 3", "arquivo-teste-stream-teste3.txt"));
            
            // helper.DeletarArquivo(Path.Combine(path, "pasta teste 3", "arquivo-teste-stream-teste3.txt"));
        }
    }
}
