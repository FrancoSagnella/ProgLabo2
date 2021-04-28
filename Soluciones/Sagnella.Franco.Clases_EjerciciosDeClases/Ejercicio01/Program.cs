using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;//Incluyo el namespace para poder acceder a las clases sin tner que escribir el namespce

namespace Ejercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.Title = "Demo de programacion 2";//Le pone el nombre a la consola, en vez de que tenga la direccion. ES UNA PROPIEDAD, SE LE ASIGNA UN VALOR

            Console.WriteLine("Ingresa tu nombre"); //ES UN METODO, SE LE PASA UN VALOR, ES COMO UNA FUNCION
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingresa tu edad");
            Int32 edad = int.Parse( Console.ReadLine()); //como cambio de string a int, no se puede castear, tengo que parsear. 


            Console.WriteLine("Su nombre es: {0} y su edad {1}", nombre, edad);//Uso las mascaras, no necesito especificar el tipo de dato, sino la posicion en la que esta despues de la coma {0}, {1}, empieza desde 0
            */
            

            Cosa cosa = new Cosa();
            Cosa cosa2 = new Cosa(2, "Hola");
            OtraCosa otraCosa = new OtraCosa();

            if(cosa == otraCosa)
            {

            }


            //Conversores, implicitos y ()explicitos 
            //Yo intento crear un nuevo objeto:
            OtraCosa c2 = new OtraCosa(4);
            OtraCosa c3 = 6;//Transformar un entero en tipo OtraCosa
            OtraCosa c4 = (OtraCosa)"Hola";//Transformar string en tipo OtraCosa

            Console.ReadKey();
        }
    }
}
