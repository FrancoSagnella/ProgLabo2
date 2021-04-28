using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase2
{
    class Program
    {
        static void Main(string[] args)
        {
            Sello.mensaje = "pedrito jose carlos";
            Console.WriteLine(Sello.Imprimir());
            Sello.Borrar();
            Console.WriteLine(Sello.Imprimir());

            Sello.mensaje = "Hola Mundo";
            Sello.color = ConsoleColor.Red;
            Sello.ImprimirColor();
            Console.WriteLine(Sello.Imprimir());

            Console.ReadKey();
        }
    }
}
