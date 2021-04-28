using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Ejemplo;

namespace TestEjemploInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto objAuto = new Auto("fiat", ConsoleColor.Yellow);
            Lapicera objLapicera = new Lapicera("fino");
            Perro objPerro = new Perro("bobby");
            Tortuga objTortuga = new Tortuga(103);

            objAuto.Precio = 15000;
            objAuto.Cantidad = 5;

            objLapicera.Precio = 22;
            objLapicera.Cantidad = 150;

            objPerro.Precio = 200;
            objPerro.Cantidad = 3;

            //objTortuga //NO tiene los miembros de IVendible

            IVendible obj = new Perro("sheik");

            Console.WriteLine(Program.FacturarUnitario(objAuto));
            Console.WriteLine(Program.FacturarUnitario(objLapicera));
            Console.WriteLine(Program.FacturarUnitario(objPerro));
            Console.WriteLine(Program.FacturarUnitario(obj));

            //Console.WriteLine(Program.FacturarUnitario(objTortuga)); //ERROR, no es de tipo IVendible

            List<IVendible> lista = new List<IVendible>();

            lista.Add(objAuto);
            lista.Add(objLapicera);
            lista.Add(objPerro);

            //lista.Add(objTortuga); //ERROR, no es de tipo IVendible

            lista.Add(obj);

            Console.WriteLine(Program.FacturarMultiple(lista));

            Console.ReadLine();
        }

        private static double FacturarUnitario(IVendible obj)
        {
            double total = 0;

            total = obj.Vender();

            return total;
        }

        private static double FacturarMultiple(List<IVendible> objs)
        {
            double total = 0;

            foreach (IVendible item in objs)
            {
                total += item.Vender();
            }          

            return total;
        }

    }
}
