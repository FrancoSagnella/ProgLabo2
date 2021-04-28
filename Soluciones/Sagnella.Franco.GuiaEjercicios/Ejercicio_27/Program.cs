using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_27
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack pila = new Stack();
            Queue cola = new Queue();
            List<int> lista = new List<int>();
            Random aux = new Random();
            int num;

            for(int i = 0; i < 20; i++)
            {
                num = aux.Next(100);
                if(num != 0)
                {
                    pila.Push(num);
                    cola.Enqueue(num);
                    lista.Add(num);
                }
                else
                {
                    i -= 1;
                }
            }

            foreach(int item in pila)
            {
                Console.WriteLine(item);
            }
            foreach (int item in cola)
            {
                Console.WriteLine(item);
            }
            foreach (int item in lista)
            {
                Console.WriteLine(item);
            }

            Stack.

            foreach (int item in pila)
            {
                Console.WriteLine(item);
            }
            foreach (int item in cola)
            {
                Console.WriteLine(item);
            }
            foreach (int item in lista)
            {
                Console.WriteLine(item);
            }


            foreach (int item in pila)
            {
                Console.WriteLine(item);
            }
            foreach (int item in cola)
            {
                Console.WriteLine(item);
            }
            foreach (int item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
