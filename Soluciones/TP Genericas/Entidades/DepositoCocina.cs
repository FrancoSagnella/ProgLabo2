using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DepositoCocina
    {
        private int capacidadMaxima;
        private List<Cocina> lista;

        public DepositoCocina(int cant)
        {
            this.lista = new List<Cocina>();
            this.capacidadMaxima = cant;
        }
        private int GetIndice(Cocina c)
        {
            int ret = -1;
            foreach (Cocina item in this.lista)
            {
                if (c.Equals(item))
                {
                    ret = this.lista.IndexOf(item);
                    break;
                }
            }
            return ret;
        }
        public bool Agregar(Cocina c)
        {
            bool ret = false;
            if (this.lista.Count() < this.capacidadMaxima)
            {
                if (this.GetIndice(c) == -1)
                {
                    ret = true;
                    this.lista.Add(c);
                }
            }
            return ret;
        }
        public static bool operator +(DepositoCocina d, Cocina c)
        {
            return d.Agregar(c);
        }
        public bool Remover(Cocina c)
        {
            bool ret = false;
            if (this.GetIndice(c) != -1)
            {
                this.lista.Remove(c);
                ret = true;
            }
            return ret;
        }
        public static bool operator -(DepositoCocina d, Cocina c)
        {
            return d.Remover(c);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad Maxima: {0}\n", this.capacidadMaxima);
            sb.AppendLine("***Listado de Autos***");
            foreach (Cocina item in this.lista)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
    }
}
