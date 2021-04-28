using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_2
{
    class Programacion_Orientada_Objetos
    {
        static void Main(string[] args)
        {
            MiClase.entero = 2;
            MiClase.Metodo1();
            Console.WriteLine(MiClase.Metodo2("5"));

            Console.ReadKey();
        }
    }
}
