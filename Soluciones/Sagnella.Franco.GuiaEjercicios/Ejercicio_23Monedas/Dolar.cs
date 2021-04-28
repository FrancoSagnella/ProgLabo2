using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monedas
{
    public class Dolar
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        static Dolar()
        {
            cotizRespectoDolar = 1;
        }

        public Dolar(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Dolar(double cantidad, double cotizacion):this(cantidad)
        {
            Dolar.cotizRespectoDolar = cotizacion;
        }


        public static explicit operator Euro(Dolar e)
        {
            return new Euro(e.cantidad * Euro.GetCotizacion);
        }
        public static explicit operator Pesos(Dolar e)
        {
            return new Pesos(e.cantidad * Pesos.GetCotizacion);
        }


        public static implicit operator Dolar(double d)
        {
            return new Dolar(d);
        }


        public static bool operator ==(Dolar d1, Dolar d2)
        {
            bool retorno = false;
            if (d1.GetCantidad == d2.GetCantidad)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ==(Dolar d, Euro e)
        {
            return d == (Dolar)e;
        }
        public static bool operator ==(Dolar d, Pesos p)
        {
            return d == (Dolar)p;
        }

        public static bool operator !=(Dolar d1, Dolar d2)
        {
            return !(d1 == d2);
        }
        public static bool operator !=(Dolar d, Euro e)
        {
            return !(d == e);
        }
        public static bool operator !=(Dolar d, Pesos p)
        {
            return !(d == p);
        }

        public static Dolar operator +(Dolar d, Euro e)
        {
            Dolar aux = new Dolar(0);
            aux = (Dolar)e;

            return new Dolar(d.GetCantidad + aux.GetCantidad);
        }
        public static Dolar operator +(Dolar d, Pesos p)
        {
            return d + (Euro)p;
        }

        public static Dolar operator -(Dolar d, Euro e)
        {
            Dolar aux = new Dolar(0);
            aux = (Dolar)d;

            return new Dolar(e.GetCantidad - aux.GetCantidad);
        }

        public static Dolar operator -(Dolar d, Pesos p)
        {
            return d - (Euro)p;
        }


        public static double GetCotizacion
        {
            get
            {
                return Dolar.cotizRespectoDolar;
            }
        }
        public double GetCantidad
        {
            get
            {
                return this.cantidad;
            }
        }
    }
}
