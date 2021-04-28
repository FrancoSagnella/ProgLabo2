using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_2
{
    class MiClase
    {
        //Atributos:* Son variables propias de la clase, es como los campos de las estructuras
            //Pueden ser estaticos o no estaticos

        //Si son estaticos los accedo con NombreDeClase.atriburo, lo mismo para metodos
            private static string cadena;//Este es privado, solo puedo acceder dentro de esta clase,este ambito
            public static int entero;

            public float reales;//no estatico, No se pueden acceder a traves de NombredeClase.Atributo, lo mismo pasa con metodos no estaticos
            
        //Propiedades:

        //Constructor:

        //Metodos:* Son funciones
            public static void Metodo1()//Los hago publicos para poder acceder o usaros desde el main
            {
                //Implementacion
                string algo = "hola";
                MiClase.cadena = algo;

                Console.WriteLine(MiClase.cadena);
            }

            public static int Metodo2(string paramUno)
            {
            //Implementacion
                int valor = int.Parse(paramUno);

                //return MiClase.entero;
                return valor;
             }

        //Sobrecargas:


    }
}
