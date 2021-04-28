using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_30_Entidades;

namespace Ejercicio_30_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Competencia c = new Competencia(3, 10);

            AutoF1 a1 = new AutoF1(4, "hola");
            AutoF1 a2 = new AutoF1(4, "hola");
            AutoF1 a3 = new AutoF1(4, "si");
            AutoF1 a4 = new AutoF1(5, "hola");
            AutoF1 a5 = new AutoF1(2, "pepe");

            if (c + a1)
            {
                Console.WriteLine("Se agrego j1");
            }
            if (!(c + a2))
            {
                Console.WriteLine("No se agrego j2");
            }
            if (c + a3)
            {
                Console.WriteLine("Se agrego j3");
            }
            if (c + a4)
            {
                Console.WriteLine("Se agrego j4");
            }
            if (!(c + a5))
            {
                Console.WriteLine("No se agrego j5");
            }

            if (!(c - a5))
            {
                Console.WriteLine("No se elimino j5");
            }
            if (c - a4)
            {
                Console.WriteLine("Se elimino j4");
            }

            foreach (AutoF1 item in c.competidores)
            {
                Console.WriteLine(item.MostrarDatos());
            }
            Console.WriteLine(a4.MostrarDatos());
            Console.ReadKey();
        }
    }
}
