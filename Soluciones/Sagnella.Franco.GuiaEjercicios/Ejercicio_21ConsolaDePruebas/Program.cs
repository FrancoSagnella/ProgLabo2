using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_21Clases;

namespace Ejercicio_21ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Kelvin k1 = 285.927777777778;
            Fahrenheit f1 = (Fahrenheit)k1;
            Celcius c1 = (Celcius)k1;

            Celcius c2 = 12.7777777777778;
            Fahrenheit f2 = (Fahrenheit)c2;
            Kelvin k2 = (Kelvin)c2;

            Fahrenheit f3 = 55;
            Celcius c3 = (Celcius)f3;
            Kelvin k3 = (Kelvin)f3;
            

            Console.WriteLine(k1.GetCantidad);
            Console.WriteLine(c1.GetCantidad);
            Console.WriteLine(f1.GetCantidad);

            Console.WriteLine(k2.GetCantidad);
            Console.WriteLine(c2.GetCantidad);
            Console.WriteLine(f2.GetCantidad);

            Console.WriteLine(k3.GetCantidad);
            Console.WriteLine(c3.GetCantidad);
            Console.WriteLine(f3.GetCantidad);

            Console.ReadKey();
        }
    }
}
