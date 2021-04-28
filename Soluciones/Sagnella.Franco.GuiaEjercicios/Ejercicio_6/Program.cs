using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_6
{
    class Ejercicio_6
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 6";

            int anioInicio;
            int anioFin;

            Console.WriteLine("Ingresa un año de inicio:");
            anioInicio = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresa un año de fin:");
            anioFin = int.Parse(Console.ReadLine());


            for (int i = anioInicio; i <= anioFin; i++)
            {
                if(i%4 == 0 && (i%100 != 0 || (i%100 == 0 && i%400 == 0)))
                {
                    Console.WriteLine("El año {0 :#,###} es biciesto", i);
                }
            }

            Console.ReadKey();
            
        }
    }
}
