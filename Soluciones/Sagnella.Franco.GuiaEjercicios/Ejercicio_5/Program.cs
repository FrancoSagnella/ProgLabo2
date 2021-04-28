using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_5
{
    class Ejercicio_5
    {
        static void Main(string[] args)
        {
            Console.Title = "Ejercicio Nro 5";

            int num;
            int acum1 = 0;
            int acum2 = 0;

            Console.WriteLine("Ingresa un numero:");
            num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)//Rrecorro desde 1 hasta el numero
            {
                for (int j = 1; j < i; j++)//para cada valor que toma i, acumulo todos los numeros que estan antes de i
                {
                    acum1 += j;
                }
                for(int j = i+1; ; j++)//para cada valor que toma i, empizo a acumular numeros que estan despues de i
                {
                    //Console.WriteLine("acum1 {0}", acum1);
                    acum2 += j;
                    if(acum2 == acum1)//si en algun momento de esta iteracion, el segundo acumulador es igual al primero, 
                                     //es poruqe se cumple la consigna
                    {
                        Console.WriteLine("El numero {0 :#,###.00} es un centro numerico", i);
                        break;
                    }
                    else if(acum2 > acum1)//Como es un bucle infinito, si la segunda acumulacion es
                                         //mas grande que la primera, ya no va a poder ser un centro, asi que corto la iteracion
                    {
                        break;
                    }
                }
                //restablezco los acumuladores a 0
                acum1 = 0;
                acum2 = 0;
            }
            Console.ReadKey();
        }
    }
}
