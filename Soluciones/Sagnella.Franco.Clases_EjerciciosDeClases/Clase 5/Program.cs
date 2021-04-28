using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Tinta t1 = new Tinta();
            Tinta t2 = new Tinta(ConsoleColor.Red, ETipoTinta.China);

            if(t1 != t2)
            {
                Console.WriteLine("t1: {0}\nt2: {1}", (string)t1, (string)t2);
            }

            Pluma p1 = new Pluma("Marca2", t2);
            Pluma p2 = new Pluma("Marca1", t2, 3);
            Pluma p3 = new Pluma();

            p2 += t2;
            Console.WriteLine(p2);
            Console.WriteLine(p2 + t1);
            p2 += t2;
            Console.WriteLine(p2);
            Console.WriteLine(p2 + t1);


            Console.WriteLine(p1 - t1);
            Console.WriteLine(p1 - t2);
            p1 -= t2;
            Console.WriteLine(p1);



            Console.WriteLine(p3);

            Console.ReadKey();
        }
    }
}
