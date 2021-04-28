using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase_7_Entidades;

namespace Clase_7_Consola_de_pruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Tempera t1 = new Tempera(ConsoleColor.Red, "Pepito", 3);
            Tempera t2 = new Tempera(ConsoleColor.White, "Pepito", 4);
            Tempera t3 = new Tempera(ConsoleColor.Red, "Pepito", 2);
            Tempera t4 = new Tempera(ConsoleColor.Black, "Faca", 5);
            Tempera t5 = new Tempera(ConsoleColor.Gray, "Mapex", 2);
            Tempera t6 = new Tempera(ConsoleColor.Gray, "Mapex", 1);
            Tempera t7 = new Tempera(ConsoleColor.Blue, "Frappa", 6);
            Tempera t8 = new Tempera(ConsoleColor.DarkYellow, "Mapex", 3);

            /*if(t1 != t2)
            {
                Console.WriteLine("Son diferentes");
            }
            if(t1 == t3)
            {
                Console.WriteLine("Son iguales");
            }

            Console.WriteLine(Tempera.Mostrar(t1));
            t1 += t3;
            Console.WriteLine(Tempera.Mostrar(t1));
            t1 += t2;
            Console.WriteLine(Tempera.Mostrar(t1));
            t3 += t4;
            Console.WriteLine(Tempera.Mostrar(t3));*/

            Paleta p1 = new Paleta();
            Paleta p2 = new Paleta();

            p1 += t1;
            p1 += t2;
            p1 += t3;//Para probar la acumulacion, le suma al t1
            p1 += t4;
            p1 += t5;
            p1 -= t6;//Para probar la resta, le resta al t5
            p1 += t7;
            p1 += t8;
            p1 -= t1;//Como le resto t1, se lo borro del array

            Console.WriteLine((string)p1);
            Console.ReadKey();
        }
    }
}
