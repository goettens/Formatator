using Formatator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Formatator
{
    public class Leitor
    {
        FileInfo Caminho { get; set; }
        public Leitor()
        {
            Console.WriteLine("Digite o nome do arquivo no diretório corrente");
            var arquivo = Console.ReadLine();

            Caminho = new FileInfo(Path.Combine(Path.GetDirectoryName(
                            Assembly.GetExecutingAssembly().Location), arquivo));

            if (!File.Exists(Caminho.FullName))
                throw new ArgumentException("O nome do arquivo não existe");

        }

        public List<Log> Escritor()
        {            
            List<Log> Logs = new List<Log>();
            DateTime TimeStampAtual = DateTime.MinValue;
            string ServidorAtual = "Não Selecionado";

            

            string[] lines = File.ReadAllLines(Caminho.FullName);

            Regex regex = new Regex(@"[0-9]");

            foreach(string line in lines)
            {
                string[] itens = line.TrimStart().Split(" ");

                //Se estiver na declaração do TimeStamp
                if (itens.Length == 3)
                {
                    ServidorAtual = itens[0];
                    string[] dataParse = itens[1].Split("-");

                    if (!Int32.TryParse(dataParse[0], out int ano) || !Int32.TryParse(dataParse[1], out int mes) || !Int32.TryParse(dataParse[2], out int dia))
                        throw new InvalidDataException("Erro durante a formatação da Data no TimeStamp");

                    string[] timeParse = itens[2].Split(":");
                    if (!Int32.TryParse(timeParse[0], out int hora) || !Int32.TryParse(timeParse[1], out int minuto) || !Int32.TryParse(timeParse[2], out int segundo))
                        throw new InvalidDataException("Erro durante a formatação da Hora no TimeStamp");

                    segundo = segundo == 1 ? 0 : segundo;
                    TimeStampAtual = new DateTime(ano, mes, dia, hora, minuto, segundo);
                }
                else if (!regex.IsMatch(line))
                    continue;
                else
                {
                    List<string> corrigido = new List<string>();
                    corrigido.Clear();
                    foreach (var i in itens)
                        if (i != "" && i != " ")
                            corrigido.Add(i);

                    if (corrigido.Count != 16)
                        throw new FormatException("O número de itens da linha de log está diferente do esperado");

                    Logs.Add(new Log()
                        {
                            Servidor = ServidorAtual,
                            TimeStamp = TimeStampAtual,
                            R = corrigido[0],
                            B = corrigido[1],
                            Swpd = corrigido[2],
                            Free = corrigido[3],
                            Buff = corrigido[4],
                            Cache = corrigido[5],
                            Si = corrigido[6],
                            So = corrigido[7],
                            Bi = corrigido[8],
                            Bo = corrigido[9],
                            In = corrigido[10],
                            Cs = corrigido[11],
                            Us = corrigido[12],
                            Sy = corrigido[13],
                            Id = corrigido[14],
                            Wa = corrigido[15]
                        }
                    );
                    TimeStampAtual = TimeStampAtual.AddSeconds(15);
                }
            }

            using (StreamWriter file =
            new StreamWriter(Caminho.DirectoryName + @"\\" + Caminho.Name + @"Ok.fa1"))
            {
                foreach (var log in Logs)
                {
                    file.WriteLine(log);
                }
            }
            return Logs;
        }
    }
}
