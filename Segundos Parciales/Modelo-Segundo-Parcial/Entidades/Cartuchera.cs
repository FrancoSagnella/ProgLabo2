using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Creo el delegado para los eventos de la clase
    public delegate void DelegadoPrecio(double precio);
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;

        //Creo un evento para la clase
        public event DelegadoPrecio EventoPrecio;
        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double ret = 0;
                foreach(T item in this.elementos)
                {
                    ret += ((T)item).precio;
                }
                return ret;
            }
        }
        public Cartuchera()
        {
            this.elementos = new List<T>();
        }
        public Cartuchera(int cant) : this()
        {
            this.capacidad = cant;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tipo de cartuchera: {0} - Capacidad {1} - Cantidad De Elementos Actuales {2} -",
                             typeof(T).Name, this.capacidad, this.elementos.Count);

            sb.AppendFormat("Precio Total {0}\n", this.PrecioTotal);
            sb.AppendLine("Listado de elementos:");
            foreach(T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c, T u)
        {
            if(c.elementos.Count < c.capacidad)
            {
                c.elementos.Add(u);

                double precio = c.PrecioTotal;
                if (precio > 85)
                {
                    c.EventoPrecio(precio);
                }
            }
            else
            {
                throw new CartucheraLlenaException();
            }
            return c;
        }
    }
}
