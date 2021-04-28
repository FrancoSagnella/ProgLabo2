using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoPrecio(object obj, EventArgs arg);
    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;

        public event DelegadoPrecio EventoPrecio;
        public List<T> Elementos
        {
            get { return this.elementos; }
        }
        public double PrecioTotal
        {
            get
            {
                double ret = 0;
                foreach (T item in this.elementos)
                {
                    ret += item.precio;
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

            sb.Append("Tipo: ");
            sb.AppendLine(typeof(T).Name);
            sb.Append("Capacidad: ");
            sb.AppendLine(this.capacidad.ToString());
            sb.Append("Elementos actuales: ");
            sb.AppendLine(this.elementos.Count.ToString());
            sb.Append("Precio Total: ");
            sb.AppendLine(this.PrecioTotal.ToString());
            sb.AppendLine("Utiles:");
            foreach (T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c, T u)
        {
            if (c.elementos.Count < c.capacidad)
            {
                c.elementos.Add(u);

                double aux = c.PrecioTotal;
                if (aux > 85)
                {
                    c.EventoPrecio(aux, new EventArgs());
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
