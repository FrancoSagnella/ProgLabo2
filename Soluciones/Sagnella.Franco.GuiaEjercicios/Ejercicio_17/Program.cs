using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjercicioLapiceras;

namespace Ejercicio_17
{
    class Program
    {
        static void Main(string[] args)
        {
            string dibujo;
            Boligrafo obj1 = new Boligrafo(100, ConsoleColor.Blue);
            Boligrafo obj2 = new Boligrafo(50, ConsoleColor.Yellow);

            if(obj1.Pintar(20, out dibujo))
            {
                Console.WriteLine(dibujo);
            }
            else
            {   
                Console.WriteLine("El boligrafo estaba vacio");
            }

            if (obj2.Pintar(20, out dibujo))
            {
                Console.WriteLine(dibujo);
            }
            else
            {
                Console.WriteLine("El boligrafo estaba vacio");
            }

            if (obj1.Pintar(20, out dibujo))
            {
                Console.WriteLine(dibujo);
            }
            else
            {
                Console.WriteLine("El boligrafo estaba vacio");
            }

            obj1.Recargar();
            obj2.Recargar();

            Console.ReadKey();
        }
    }
}
