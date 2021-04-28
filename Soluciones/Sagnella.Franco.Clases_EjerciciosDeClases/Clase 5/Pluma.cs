using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_5
{
    class Pluma
    {
        private string marca;
        private Tinta tinta;
        private int cantidad;

        public Pluma()
        {
            this.marca = "Sin Marca";
            this.tinta = new Tinta();
            this.cantidad = 1;
        }
        public Pluma(string marca):this()
        {
            this.marca = marca;
        }
        public Pluma(string marca, Tinta tinta):this(marca)
        {
            this.tinta = tinta;
        }
        public Pluma(string marca, Tinta tinta, int cantidad):this(marca, tinta)
        {
            this.cantidad = cantidad;
        }

        private string Mostrar()
        {
            return "Marca: " + this.marca + "\nTinta: " + Tinta.Mostrar(this.tinta) + "\nCantidad: " + this.cantidad;
        }

        public static bool operator ==(Pluma p, Tinta t)
        {
            bool ret = false;
            if(p.tinta == t)
            {
                ret = true;
            }
            return ret;
        }
        public static bool operator !=(Pluma p, Tinta t)
        {
            return !(p == t);
        }

        public static Pluma operator +(Pluma p, Tinta t)
        {
            int cantAux = p.cantidad;
            if (p == t)
            {
                cantAux++;
            }
            return new Pluma(p.marca, p.tinta, cantAux);
        }
        public static Pluma operator -(Pluma p, Tinta t)
        {
            int cantAux = p.cantidad;
            if (p == t)
            {
                cantAux--;
            }
            return new Pluma(p.marca, p.tinta, cantAux);
        }

        public static implicit operator string(Pluma p)
        {
            return p.Mostrar();
        }
    }
}
