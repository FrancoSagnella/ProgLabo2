using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private ECilindrada cilindrada;

        public Moto(string marca, EPais pais, string modelo, float precio, ECilindrada cilindrada)
            :base(marca, pais, precio, modelo)
        {
            this.cilindrada = cilindrada;
        }
        public static bool operator ==(Moto a, Moto b)
        {
            bool ret = false;

            if ((Vehiculo)a == (Vehiculo)b && a.cilindrada == b.cilindrada)
            {
                ret = true;
            }

            return ret;
        }
        public static bool operator !=(Moto a, Moto b)
        {
            return !(a == b);
        }
        public static implicit operator float(Moto a)
        {
            return a.precio;
        }
        public override bool Equals(object obj)
        {
            bool ret = false;

            if (obj is Moto)
            {
                ret = this == (Moto)obj;
            }

            return ret;
        }
        public override string ToString()
        {
            return String.Format("{0}Cilindrada: {1}\n", (string)this, this.cilindrada);
        }
    }
}
