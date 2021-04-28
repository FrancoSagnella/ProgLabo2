using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_19
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumador obj1 = new Sumador();
            Sumador obj2 = new Sumador();

            Console.WriteLine(obj1.Sumar(1, 3));
            Console.WriteLine(obj1.Sumar("Hola ", "Como estas"));

            double SumasTotales = obj1 + obj2;
            
            Console.WriteLine(SumasTotales);
            if(!(obj1 | obj2))
            {
                Console.WriteLine("Son distintos");
            }

            Console.WriteLine(obj2.Sumar(1, 3));
            Console.WriteLine(obj2.Sumar("Hola ", "Como estas"));

            SumasTotales = obj1 + obj2;

            Console.WriteLine(SumasTotales);
            if (obj1 | obj2)
            {
                Console.WriteLine("Son iguales");
            }

            Console.ReadKey();
        }
    }
}
