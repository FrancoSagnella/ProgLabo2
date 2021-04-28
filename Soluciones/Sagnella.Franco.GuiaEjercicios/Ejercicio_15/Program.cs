using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    class Program
    {
        static char respuesta = 's';
        static void Main(string[] args)
        {
            while (Program.respuesta == 's')
            {
                Console.WriteLine("ingrese primer operando: ");
                Calculadora.primerOperador = double.Parse(Console.ReadLine());

                Console.WriteLine("ingrese segundo operando: ");
                Calculadora.segundoOperador = double.Parse(Console.ReadLine());

                Console.WriteLine("ingrese operador: ");
                Calculadora.operador = char.Parse(Console.ReadLine());

                if (Calculadora.Calcular(Calculadora.primerOperador, Calculadora.segundoOperador, Calculadora.operador))
                {
                    Console.WriteLine("El resultado es: {0 :#,###.00}", Calculadora.resultado);
                }
                else
                {
                    Console.WriteLine("Error, operador invalido o dividion por 0");
                }

                Console.WriteLine("Continuar calculando? s/n");
                Program.respuesta = char.Parse(Console.ReadLine());
            }

            Console.ReadKey();
        }
    }
}
