using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_2
{
    class Ejercicio_2
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 2";

            double num;

            Console.WriteLine("Ingresa un numero");
            num = int.Parse(Console.ReadLine());

            while(num == 0)
            {
                Console.WriteLine("Error: ¡Reingresar numero!");
                num = int.Parse(Console.ReadLine());
            }

            Console.Write("El cuadraro del numero es {0 :#,###.00} y el cubo es {1 :#,###.00}", Math.Pow(num, 2), Math.Pow(num, 3));

            Console.ReadKey();
        }
    }
}
