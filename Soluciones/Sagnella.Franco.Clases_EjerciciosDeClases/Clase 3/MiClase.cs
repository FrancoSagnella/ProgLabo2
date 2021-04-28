using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_3
{
    class MiClase
    {
        public int atriburo;
        public static int atributoEstatico;
        private static int contadorDeInstancias;
        //constructor no estatico, inicializan objetos o instancias, atributos de las instancias
        //Podria agregarle parametros si creo un solo constructor, es el unico que voy a poder usar, porque el 
        //default desaparece
        public MiClase()//Si creo uno, anulo el por defecto, el por defecto inicializa en 0, false o null
        {
            //sentencias inicializando los atributos no estaticos que posee
            this.atriburo = 7;
            MiClase.contadorDeInstancias++;
        }

        //Constructores estaticos, inicializan clases, atributos de las clases
        //No permite parametros
        static MiClase()//No peude tener modificadores de acceso (public, private), actua siempre como publico
        {
            MiClase.atributoEstatico = 6;
            MiClase.contadorDeInstancias = 0;
        }
        //Se invocan una sola vez, al construir la primer instancia, con las siguientes instancias ya no se invoca

        public static void MostrarCantidadObjetos()
        {
            Console.WriteLine(MiClase.contadorDeInstancias);
        }
    }
}
