using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryProyecto1PP
{
    internal class render
    {
       private static Random rnd = new Random();

        public static int GenerarNumeroRandom() 
        {
            int Numero = rnd.Next(1, 100);
            return Numero;
        }
    }
}
