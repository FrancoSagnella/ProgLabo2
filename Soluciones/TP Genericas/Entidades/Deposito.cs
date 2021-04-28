using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Deposito<T>
    {
        private int capacidadMaxima;
        private List<T> lista;

        public Deposito(int cap)
        {
            this.capacidadMaxima = cap;
            this.lista = new List<T>();
        }
        private int Getindice(T a)
        {
            int ret = -1;
            foreach(T item in this.lista)
            {
                if (a.Equals(item))
                {
                    ret = this.lista.IndexOf(item);
                    break;
                }
            }
            return ret;
        }
        public bool Agregar(T a)
        {
            bool ret = false;
            if(this.lista.Count() < this.capacidadMaxima)
            {
                if(this.Getindice(a) == -1)
                {
                    this.lista.Add(a);
                    ret = true;
                }
            }
            return ret;
        }
        public static bool operator +(Deposito<T> d, T a)
        {
            return d.Agregar(a);
        }
        public bool Remover(T a)
        {
            bool ret = false;
            if(this.Getindice(a) != -1)
            {
                this.lista.Remove(a);
                ret = true;
            }
            return ret;
        }
        public static bool operator -(Deposito<T> d, T a)
        {
            return d.Remover(a);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad Maxima: {0}\n", this.capacidadMaxima);
            sb.AppendFormat("***Lista de {0}s***\n", typeof(T).Name);

            /*if(this.lista is List<Auto>)
            {
                sb.AppendLine("***Lista de Autos***");
            }
            else if(this.lista is List<Cocina>)
            {
                sb.AppendLine("***Lista de Cocinas***");
            }*/

            foreach(T item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
