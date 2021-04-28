using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_1
{
    class Ejercicio_01
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 01";
            int num;
            int i;
            int minimo = 0;
            int maximo = 0;
            int acumulador = 0;
            float promedio;

            for (i = 0; i < 5; i++)
            {
                Console.WriteLine("Ingrese un numero: ");
                num = int.Parse(Console.ReadLine());

                if(i == 0 || num < minimo)
                {
                    minimo = num;
                }
                if(i == 0 || num > maximo)
                {
                    maximo = num;
                }

                acumulador += num;
            }

            promedio = (float)acumulador / i;

            Console.Write("El minimo ingresado es {0 :#,###.00} el maximo es {1 :#,###.00} y el promedio es {2 :#,###.00}", minimo, maximo, promedio);
            Console.ReadKey();
        }
    }
}
