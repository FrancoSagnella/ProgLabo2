using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Clase_5
{ 
    class Tinta
    {
        private ConsoleColor color;
        private ETipoTinta tipo;


        public Tinta()
        {
            this.color = ConsoleColor.Black;
            this.tipo = ETipoTinta.Comun;
        }
        public Tinta(ConsoleColor color):this()
        {
            this.color = color;
        }
        public Tinta(ConsoleColor color, ETipoTinta tipo):this(color)
        {
            this.tipo = tipo;
        }

        private string Mostrar()//Como esta funcion es privada y de instancia, acceo a travez de la publica
        {
            return "El color es: " + this.color + " El tipo de tinta es: " + this.tipo;//Arma el string y lo devuelve
        }
        public static string Mostrar(Tinta t)
        {
            return t.Mostrar();//Desde esta funcion que es publica y estatica, y la puedo llamar dede el main
        }                      //puedo llamar al Mostrar privado, que me devuelve la string con los datos, y esta lo vuelve a devolver


        public static bool operator ==(Tinta t1, Tinta t2)
        {
            bool ret = false;

            if(t1.color == t2.color && t1.tipo == t2.tipo)
            {
                ret = true;
            }

            return ret;
        }
        public static bool operator !=(Tinta t1, Tinta t2)
        {
            return !(t1 == t2);
        }

        public static explicit operator string(Tinta t1)
        {
            return t1.Mostrar();
        }
    }
}
