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
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Finalizado. Pressione qualquer tecla para sair.");
            }
            Console.Read();
        }
    }
}
