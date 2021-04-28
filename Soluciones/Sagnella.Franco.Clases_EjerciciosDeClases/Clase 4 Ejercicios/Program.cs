using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4_Ejercicios
{
    class Program
    {
        static void Main(string[] args)
        {
            Cosa c = new Cosa();
            Cosa c2 = new Cosa(4, "chau");
            Cosa c3 = new Cosa("Saludos");

            c.Mostrar();
            c2.Mostrar();
            c3.Mostrar();
            

            Console.ReadKey();
        }
    }
}
