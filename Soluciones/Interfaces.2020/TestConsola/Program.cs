using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Interfaces;

namespace TestConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            MiClase obj = new MiClase("Valor string");

            obj.PropiedadSE = 98;
            Console.WriteLine(obj.PropiedadSL);
            Console.WriteLine(obj.PropiedadLE);

            double a = obj.MetodoConParametros(2, 8);


            obj.MetodoSinRetornoNiParametros();

            MiClaseDerivada mcd = new MiClaseDerivada("valor1", "valor2");

            mcd.OtroMetodo();
            mcd.MetodoSinRetornoNiParametros();


            IMiInterface miVariable;
            MiClase miOtraVariable;
            IMiOtraInterface otraOtraVariable;

            miOtraVariable = obj;
            miOtraVariable = mcd;
            miVariable = obj;
            miVariable = mcd;
            otraOtraVariable = mcd;
           /// otraOtraVariable = obj;


            ClaseIMiembrosRepetidos cmr = new ClaseIMiembrosRepetidos();

            



            cmr.Metodo();
            ((IMiembrosRepetidos2)cmr).Metodo();



            IMiInterface variableInterface;
            variableInterface = obj;

            Program.Mostrar(obj);
            Program.Mostrar(variableInterface);

            //Program.Mostrar("asdfasd"); //ERROR, no es de tipo IMiInterface


            ClaseConstructorDefecto objClaseConstructorDefecto = new ClaseConstructorDefecto();
            MiOtraClase miOtraClase = new MiOtraClase();

            miOtraClase.Metodo(objClaseConstructorDefecto);
            objClaseConstructorDefecto = miOtraClase.MetodoRetorno(objClaseConstructorDefecto);

            ClaseGenerica<MiOtraClase> objGenerica = new ClaseGenerica<MiOtraClase>();

            objGenerica.Metodo(new MiOtraClase());



            Console.ReadLine();
        }

        private static void Mostrar(IMiInterface algo)
        {
            Console.WriteLine(algo.PropiedadSL);
            Console.WriteLine(((MiClase)algo).atributo);
        }
    }
}
