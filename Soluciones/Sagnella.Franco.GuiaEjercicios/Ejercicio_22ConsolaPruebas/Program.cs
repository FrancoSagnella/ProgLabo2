using Ejercicio_22Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_22ConsolaPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            NumeroDecimal dec = 9;
            NumeroBinario bin = "1001";

            if(bin == dec)
            {
                Console.WriteLine(dec - bin);
                Console.WriteLine(bin - dec);
            }
            

            Console.ReadKey();
        }
    }
}
