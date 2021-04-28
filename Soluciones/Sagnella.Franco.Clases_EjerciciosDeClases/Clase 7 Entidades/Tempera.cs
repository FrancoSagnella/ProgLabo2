using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_7_Entidades
{
    public class Tempera
    {
        private ConsoleColor color;
        private string marca;
        private int cantidad;

        #region Constructor   
        public Tempera(ConsoleColor color, string marca, int cantidad)
        {
            this.cantidad = cantidad;
            this.color = color;
            this.marca = marca;
        }
        #endregion

        #region Metodos
        private string Mostrar()
        {
            StringBuilder aux = new StringBuilder();//Para construir una cadena compuesta
            //Uso los metodos que tiene que me permiten anexar  las cadenas
            aux.Append("Color: ");
            aux.AppendLine(this.color.ToString());
            aux.Append("Marca: ");
            aux.AppendLine(this.marca);
            aux.Append("Cantidad: ");
            aux.AppendLine(this.cantidad.ToString());

            return aux.ToString();//Retorno la instancia parseada a string
        }
        public static string Mostrar(Tempera t)
        {
            return t.Mostrar();
        }
        #endregion

        #region Sobrecargas
        public static bool operator ==(Tempera t1, Tempera t2)
        {
            bool retorno = false;

            if((object)t1 == null && (object)t2 == null)
            {
                retorno = true;
            }
            else
            {
                if((object)t1 != null && (object)t2 != null)
                {
                    if(t1.color == t2.color && t1.marca == t2.marca)
                    {
                      retorno = true;
                    }
                }
            }
 
            return retorno;
        }
        public static bool operator !=(Tempera t1, Tempera t2)
        {
            return !(t1 == t2);
        }

        public static implicit operator int(Tempera t1)
        {
            return t1.cantidad;
        }

        public static Tempera operator +(Tempera t1, Tempera t2)
        {
            if(t1 == t2)
            {
                t1 += t2.cantidad;
            }
            return t1;
        }
        public static Tempera operator +(Tempera t, int suma)
        {
            t.cantidad += suma;
            return t;
        }
        public static Tempera operator -(Tempera t1, Tempera t2)
        {
            if (t1 == t2)
            {
                t1 -= t2.cantidad;
            }
            return t1;
        }
        public static Tempera operator -(Tempera t, int suma)
        {
            t.cantidad -= suma;
            return t;
        }
        #endregion
    }
}
