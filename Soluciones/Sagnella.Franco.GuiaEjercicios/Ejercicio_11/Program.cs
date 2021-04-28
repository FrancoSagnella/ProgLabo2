using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int valor;
            int contador = 0;
            int min = 0;
            int max = 0;
            float promedio = 0;

            while(contador != 10)
            {
                Console.Write("Ingresa un numero entre -100 y 100: ");
                valor = int.Parse(Console.ReadLine());

                if(Validacion.Validar(valor, -100, 100))
                {
                    if(contador == 0 || valor < min)
                    {
                        min = valor;
                    }
                    if(contador == 0 || valor > max)
                    {
                        max = valor;
                    }
                    contador++;
                    promedio += valor;
                }
                else
                {
                    Console.WriteLine("¡ERROR!: el numero tiene que estar en el rango especificado");
                }
            }
            promedio /= contador;
            Console.WriteLine("El valor minimo ingresado es {0 :#,###.00} el maximo es {1 :#,###.00} y el promedio es {2 :#,###.00}", min, max, promedio);

            Console.ReadKey();
        }
    }
}
