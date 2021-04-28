using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        public abstract bool PreciosCuidados { get; }

        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            return String.Format("Marca: {0} - Precio: {1}", this.marca, this.precio);
        }
        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
