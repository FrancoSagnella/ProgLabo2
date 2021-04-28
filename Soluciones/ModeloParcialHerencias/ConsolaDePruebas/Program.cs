using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            Lavadero miLavadero = new Lavadero(100, 500, 300);

            Auto a1 = new Auto("aaa-111", 4, EMarcas.Zanella, 5);
            Auto a2 = new Auto("aaa-222", 4, EMarcas.Honda, 2);
            Auto a3 = new Auto("asd-234", 4, EMarcas.Ford, 3);

            Camion c1 = new Camion("fff-111", 6, EMarcas.Scania, 2);
            Camion c2 = new Camion("ggg-111", 8, EMarcas.Honda, 5);

            Moto m1 = new Moto("kkk-111", 2, EMarcas.Iveco, 12);
            Moto m2 = new Moto("mmm-111", 2, EMarcas.Fiat, 12);

            miLavadero += a1;
            miLavadero += a1;
            miLavadero += a2;
            miLavadero += c1;
            miLavadero += c2;
            miLavadero += m1;
            miLavadero += m2;
            miLavadero += c2;

            Console.WriteLine(miLavadero.GetLavadero);
            Console.ReadKey();

            //miLavadero -= a2;
            miLavadero -= a3;
            //miLavadero -= a2;
            miLavadero -= c2;

            Console.WriteLine(miLavadero.GetLavadero);
            Console.ReadKey();

            Console.WriteLine(miLavadero.MostrarTotalFacturado());
            Console.WriteLine(miLavadero.MostrarTotalFacturado(EVehiculos.Auto));
            Console.WriteLine(miLavadero.MostrarTotalFacturado(EVehiculos.Camion));
            Console.WriteLine(miLavadero.MostrarTotalFacturado(EVehiculos.Moto));
            Console.ReadKey();
            
            miLavadero.Vehiculos.Sort(miLavadero.OrdenarVehiculosPorMarca);
            Console.WriteLine(miLavadero.GetLavadero);
            Console.ReadKey();

            miLavadero.Vehiculos.Sort(Lavadero.OrdenarVehiculosPorPatente);
            Console.WriteLine(miLavadero.GetLavadero);
            Console.ReadKey();
        }
    }
}
