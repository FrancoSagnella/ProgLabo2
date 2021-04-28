using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Alumno obj1 = new Alumno("Sagnella", 123, "Franco");
            Alumno obj2 = new Alumno("Rodriguez", 124, "Pepe");
            Alumno obj3 = new Alumno("Sanchez", 125, "Jorge");

            obj1.Estudiar(3, 5);
            obj2.Estudiar(5, 6);
            obj3.Estudiar(4, 4);

            obj1.CalcularFinal();
            obj2.CalcularFinal();
            obj3.CalcularFinal();

            obj1.Mostrar();
            obj2.Mostrar();
            obj3.Mostrar();
            
            Console.ReadKey();
        }
    }
}
