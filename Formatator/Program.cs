using Formatator.Models;
using System;
using System.Collections.Generic;

namespace Formatator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Man");
            try
            {
                Leitor leitor = new Leitor();
                List<Log> logster = leitor.Escritor();
                foreach(Log a in logster)
                {
                    Console.WriteLine(a);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Read();
        }
    }
}
