using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoAuto
    {
        private int capacidadMaxima;
        private List<Auto> lista;

        public DepositoAuto(int cant)
        {
            this.lista = new List<Auto>();
            this.capacidadMaxima = cant;
        }
        private int GetIndice(Auto a)
        {
            int ret = -1;
            foreach(Auto item in this.lista)
            {
                if(a.Equals(item))
                {
                    ret = this.lista.IndexOf(item);
                    break;
                }
            }
            return ret;
        }
        public bool Agregar(Auto a)
        {
            bool ret = false;
            if(this.lista.Count() < this.capacidadMaxima)
            {
                if(this.GetIndice(a) == -1)
                {
                    ret = true;
                    this.lista.Add(a);
                }
            }
            return ret;
        }
        public static bool operator +(DepositoAuto d, Auto a)
        {
            return d.Agregar(a);
        }
        public bool Remover(Auto a)
        {
            bool ret = false;
            if(this.GetIndice(a) != -1)
            {
                this.lista.Remove(a);
                ret = true;
            }
            return ret;
        }
        public static bool operator -(DepositoAuto d, Auto a)
        {
            return d.Remover(a);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad Maxima: {0}\n", this.capacidadMaxima);
            sb.AppendLine("***Listado de Autos***");
            foreach(Auto item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
    
}
