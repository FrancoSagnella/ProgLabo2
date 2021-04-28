using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Billetes;

namespace Ejercicio_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Pesos p1 = new Pesos();
            Dolar d1 = new Dolar(2);
            p1 = 2;
            d1 = (Dolar)p1;
            Console.WriteLine(p1.GetCantidad);
            Console.WriteLine(d1.GetCantidad);

            Pesos p2 = p1 + d1;
            Dolar d2 = d1 + p1;
            Console.WriteLine(p2.GetCantidad);
            Console.WriteLine(d2.GetCantidad);

            Pesos p3 = new Pesos();
            p3 = (Pesos)d2;
            Console.WriteLine(p3.GetCantidad);

            p3 += d2;
            Console.WriteLine(p3.GetCantidad);



            Euro e1 = new Euro(0.85);
            Dolar d3 = (Dolar)e1;
            Pesos p4 = (Pesos)e1;

            Console.WriteLine(e1.GetCantidad);
            Console.WriteLine(d3.GetCantidad);
            Console.WriteLine(p4.GetCantidad);
            p3 = 0;
            p3 += e1;
            Console.WriteLine(p3.GetCantidad);

            Console.ReadKey();
        }
    }
}
