using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio_29;

namespace Ejercicio_29_Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipo e = new Equipo(3, "Equipazo");

            Jugador j1 = new Jugador(123456, "pepe", 3, 4);
            Jugador j2 = new Jugador(123456, "leandro", 15, 6);
            Jugador j3 = new Jugador(321345, "jose", 2, 2);
            Jugador j4 = new Jugador(432111, "pepe", 1, 6);
            Jugador j5 = new Jugador(333221, "pepe", 1, 6);

            if (e + j1)
            {
                Console.WriteLine("Se agrego j1");
            }
            if (!(e + j2))
            {
                Console.WriteLine("No se agrego j2");
            }
            if (e + j3)
            {
                Console.WriteLine("Se agrego j3");
            }
            if (e + j4)
            {
                Console.WriteLine("Se agrego j4");
            }
            if (!(e + j5))
            {
                Console.WriteLine("No se agrego j5");
            }

            foreach(Jugador item in e.jugadores)
            {
                Console.WriteLine(item.MostrarDatos());
            }

            Console.ReadKey();
        }
    }
}
