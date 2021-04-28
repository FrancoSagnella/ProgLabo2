using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Estoy en el Main e invoco a la función 1...");

            try
            {
                Program.Funcion1();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
                Console.ReadLine();
            }

        }

        private static void Funcion1()
        {
            Console.WriteLine("Estoy en el función 1 e invoco a la función 2...");

            Program.Funcion2();
        }
        private static void Funcion2()
        {
            Console.WriteLine("Estoy en el función 2 e invoco a la función 3...");

            Program.Funcion3();
        }

        private static void Funcion3()
        {
            Console.WriteLine("Estoy en el función 3 e invoco a la función 4...");

            try
            {
                Program.Funcion4();

            }
            catch (Exception e)
            {

                Console.WriteLine(e.StackTrace);
            }
        }

        private static void Funcion4()
        {
            Console.WriteLine("Estoy en el función 4 e invoco a la función 5...");

            Program.Funcion5();
        }

        private static void Funcion5()
        {
            Console.WriteLine("Estoy en el función 5 y genero una excepción...");

            Console.WriteLine("Escriba un número");

            int i = int.Parse(Console.ReadLine());
        }
    }
}
