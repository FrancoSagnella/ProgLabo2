using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int acumulador = 0;
            char respuesta;
            do
            {
                Console.WriteLine("Ingrese un numero para sumar");
                acumulador += int.Parse(Console.ReadLine());

                Console.WriteLine("Quiere continuar con el ingreso? responda S o N");
                respuesta = char.Parse(Console.ReadLine());

            } while (ValidarRespuesta.ValidaS_N(respuesta));
            Console.Write("La suma es {0 :#,###.00}", acumulador);
            Console.ReadKey();
        }
    }
}
