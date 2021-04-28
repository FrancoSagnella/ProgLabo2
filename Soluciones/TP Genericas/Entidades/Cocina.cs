using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cocina
    {
        private int codigo;
        private bool esIndustrial;
        private double precio;

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
        }
        public bool EsIndustrial
        {
            get
            {
                return this.esIndustrial;
            }
        }
        public double Precio
        {
            get
            {
                return this.precio;
            }
        }
        public Cocina(int codigo, double precio, bool esIndustrial)
        {
            this.codigo = codigo;
            this.esIndustrial = esIndustrial;
            this.precio = precio;
        }
        public static bool operator ==(Cocina c1, Cocina c2)
        {
            bool ret = false;
            if (c1.codigo == c2.codigo && c1.esIndustrial == c2.esIndustrial && c1.precio == c2.precio)
            {
                ret = true;
            }
            return ret;
        }
        public static bool operator !=(Cocina c1, Cocina c2)
        {
            return !(c1 == c2);
        }
        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Cocina)
            {
                ret = (Cocina)obj == this;
            }
            return ret;
        }
        public override string ToString()
        {
            return String.Format("Codigo: {0} - Precio: {1} - Es Industrial?: {2}", this.codigo, this.precio, this.esIndustrial.ToString());
        }
    }
}
