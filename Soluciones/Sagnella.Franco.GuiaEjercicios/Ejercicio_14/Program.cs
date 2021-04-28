using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el lado de un cuadrado:");
            Console.WriteLine("El area es: {0 :#,###.00}", CalculoDeArea.CalcularCuardrado(double.Parse(Console.ReadLine())));

            Console.WriteLine("Ingrese base y altura de un triangulo:");
            Console.WriteLine("El area es: {0 :#,###.00}", CalculoDeArea.CalcularTriangulo(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine())));

            Console.WriteLine("Ingrese el radio de un circulo:");
            Console.WriteLine("El area es: {0 :#,###.00}", CalculoDeArea.CalcularCirculo(double.Parse(Console.ReadLine())));

            Console.ReadKey();
        }
    }
}
