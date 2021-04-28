using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculo
    {
        private ETipo tipo;

        public Auto(string modelo, float precio, Fabricante fabricante, ETipo tipo)
            :base(precio, modelo, fabricante)
        {
            this.tipo = tipo;
        }
        public static bool operator ==(Auto a, Auto b)
        {
            bool ret = false;

            if((Vehiculo)a == (Vehiculo)b && a.tipo == b.tipo)
            {
                ret = true;
            }

            return ret;
        }
        public static bool operator !=(Auto a, Auto b)
        {
            return !(a == b);
        }
        public static explicit operator float(Auto a)
        {
            return a.precio;
        }
        public override bool Equals(object obj)
        {
            bool ret = false;

            if(obj is Auto)
            {
                ret = this == (Auto)obj;
            }

            return ret;
        }
        public override string ToString()
        {
            return String.Format("{0}Tipo: {1}\n", (string)this, this.tipo);
        }
    }
}
