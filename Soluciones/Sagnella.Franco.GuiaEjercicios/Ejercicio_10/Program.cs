using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese alto de la piramide:");
            int alto = int.Parse(Console.ReadLine());

            string piso = "";
            int contador = 0;

            for (int i = 0; i < alto; i++)
            {
                for (int j = contador; j < alto; j++)
                {
                    piso += " ";
                }
                for (int j = 0; j <= i + contador; j++)
                {
                    piso += "*";
                }
                contador++;
                piso += "\n";
            }
            Console.WriteLine(piso);
            Console.ReadKey();
        }
    }
}
