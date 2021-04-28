using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_3
{
    class Ejercicio_3
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 3";

            int num;

            Console.WriteLine("Ingresa un numero");
            num = int.Parse(Console.ReadLine());

            if (num <= 1)
            {
                Console.WriteLine("No hay nunign numero primo entre 0 y {0 :#,###.00}", num);
            }
            else
            {
                for (int i = 1; i < num; i++)
                {
                    int cont = 0;
                    for(int j = 1; j <= i; j++)
                    {
                        if(i%j == 0)
                        {
                            cont++;
                        }   
                    }
                    if(cont == 2)
                    {
                        Console.WriteLine(i);
                    }
                }    
            }
            Console.ReadKey();
        }
    }
}
