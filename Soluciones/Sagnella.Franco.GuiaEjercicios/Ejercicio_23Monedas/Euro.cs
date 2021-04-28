using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monedas
{
    public class Euro
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        /*CONSTRUCTORES*/
        static Euro()
        {
            cotizRespectoDolar = 0.85;
        }
        public Euro(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public Euro(double cantidad, double cotizacion):this(cantidad)
        {
            Euro.cotizRespectoDolar = cotizacion;
        }
        /*OPERADORES EXPLICITOS*/
        public static explicit operator Pesos(Euro e)
        {
            Dolar aux = new Dolar(0);
            aux = (Dolar)e;

            return new Pesos(aux.GetCantidad * Pesos.GetCotizacion);
        }
        public static explicit operator Dolar(Euro e)
        {
            return new Dolar(e.cantidad / Euro.GetCotizacion);
        }

        /*OPERADORES IMPLICITOS*/
        public static implicit operator Euro(double d)
        {
            return new Euro(d);
        }

        /*OPERADORES DE COMPARACION*/
        public static bool operator ==(Euro e1, Euro e2)
        {
            bool retorno = false;
            if (e1.GetCantidad == e2.GetCantidad)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ==(Euro e, Dolar d)
        {
            return e == (Euro)d;
        }
        public static bool operator ==(Euro e, Pesos p)
        {
            return e == (Euro)p;
        }

        public static bool operator !=(Euro e1, Euro e2)
        {
            return !(e1 == e2);
        }
        public static bool operator !=(Euro e, Dolar d)
        {
            return !(e == d);
        }
        public static bool operator !=(Euro e, Pesos p)
        {
            return !(e == p);
        }

        /*OPERADORES DE SUMA*/
        public static Euro operator +(Euro e, Dolar d)
        {
            Euro aux = new Euro(0);
            aux = (Euro)d;

            return new Euro(e.GetCantidad + aux.GetCantidad);
        }
        public static Euro operator +(Euro e, Pesos p)
        {
            return e + (Dolar)p;
        }


        /*OPERADORES DE RSTA*/
        public static Euro operator -(Euro e, Dolar d)
        {
            Euro aux = new Euro(0);
            aux = (Euro)d;

            return new Euro(e.GetCantidad - aux.GetCantidad);
        }

        public static Euro operator -(Euro e, Pesos p)
        {
            return e - (Dolar)p;
        }

        /*PROPIEDADES*/
        public static double GetCotizacion
        {
            get
            {
                return Euro.cotizRespectoDolar;
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
