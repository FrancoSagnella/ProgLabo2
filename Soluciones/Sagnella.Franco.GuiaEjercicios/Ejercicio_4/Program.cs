using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    class Ejercicio_4
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 4";

            int contador = 0;
            int acumulador = 0;

            for(int i = 1; ;i++)
            {
                for(int j = 1; j < i; j++)
                {
                    if (i%j == 0)
                    {
                        acumulador += j;
                    }    
                }
                if(acumulador == i)
                {
                    contador++;
                    Console.WriteLine("{0 :#,###.00} es un numero perfecto", i);
                    if(contador == 4)
                    {
                        break;
                    }
                }
                acumulador = 0;
            }
            Console.ReadKey();
        }
    }
}
