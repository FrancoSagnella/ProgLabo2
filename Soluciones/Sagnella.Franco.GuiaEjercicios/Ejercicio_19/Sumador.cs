using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_19
{
    class Sumador
    {
        private int cantidadSumas;

        public Sumador(int cantidadSumas)
        {
            this.cantidadSumas = cantidadSumas;
        }
        public Sumador() : this(0)//this() hace reerencia a otro constructor, depende de lo que pongo el parentesis
        {

        }
        public long Sumar(long a, long b)
        {
            this.cantidadSumas++;
            return a + b;
        }
        public string Sumar(string a, string b)
        {
            this.cantidadSumas++;
            return a + b;
        }

        public static explicit operator int(Sumador s)//Despues lo puedo escribir como (int)Sumador, y se va a meter a esta linea de codigo
        {
            return s.cantidadSumas;
        }

        public static long operator +(Sumador s1, Sumador s2)//Me va a dejar hacer Sumador + Sumador y va a pasar todo esto
        {
            return (int)s1 + (int)s2;//Hago las conversiones que me van a devolver la cantidad de sumas, los sumo y despues devuelvo eso
        }

        public static bool operator |(Sumador s1, Sumador s2)//lo mismo que antes, esto me va a dejar hacer Sumador | Sumador y va a pasar todo esto
        {
            bool retorno = false;
            if((int)s1 == (int)s2)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
