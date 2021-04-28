using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_26
{
    class Program
    {
        static void Main(string[] args)
        {
            Random aux = new Random();
            int[] array = new int[20];

            for(int i = 0; i < 20; i++)
            {
                int num = aux.Next(100);
                if(num != 0)
                {
                    array[i] = num;
                }
                else 
                {
                    i -= 1;
                }
            }
            foreach(int item in array)
            {
                Console.WriteLine(item);
            }
            Array.Sort(array);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
            Array.Reverse(array);
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
