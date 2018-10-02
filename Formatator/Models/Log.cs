using System;

namespace Formatator.Models
{
    public class Log
    {
        public string Servidor { get; set; }
        public DateTime TimeStamp { get; set; }
        public string R { get; set; }
        public string B { get; set; }
        public string Swpd { get; set; }
        public string Free { get; set; }
        public string Buff { get; set; }
        public string Cache { get; set; }
        public string Si { get; set; }
        public string So { get; set; }
        public string Bi { get; set; }
        public string Bo { get; set; }
        public string In { get; set; }
        public string Cs { get; set; }
        public string Us { get; set; }
        public string Sy { get; set; }
        public string Id { get; set; }
        public string Wa { get; set; }

        public override string ToString()
        { 
            string x = " ";
            string saida = Servidor + x + TimeStamp + x + R + x + B + x + Swpd + x + Free + x + Buff + x + Cache + x + Si + x +
                So + x + Bi + x + Bo + x + In + x + Cs + x + Us + x + Sy + x + Id + x + Wa;
            return saida;
        }
    }
}
