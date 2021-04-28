using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Billetes
{
    public class Pesos
    {
        private double cantidad;
        private static double cotizRespectoDolar;

        static Pesos()
        {
            Pesos.cotizRespectoDolar = 38.33;
        } 
        public Pesos():this(0)  
        {

        }
        public Pesos(double cantidad)
        {
            this.cantidad = cantidad;
        }


        public static explicit operator Dolar(Pesos p)
        {
            return new Dolar(p.GetCantidad / Pesos.GetCotizacion);
        }
        public static explicit operator Euro(Pesos p)
        {
            Dolar aux = new Dolar();
            aux = (Dolar)p;
            return new Euro(aux.GetCantidad * Euro.GetCotizacion);
        }


        public static implicit operator Pesos(double d)
        {
            return new Pesos(d);
        }


        public static bool operator ==(Pesos p1, Pesos p2)
        {
            bool retorno = false;
            if(p1.GetCantidad == p2.GetCantidad)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ==(Pesos p, Dolar d)
        {
            return p == (Pesos)d;
        }
        public static bool operator ==(Pesos p, Euro e)
        {
            return p == (Pesos)e;
        }

        public static bool operator !=(Pesos p1, Pesos p2)
        {
            return !(p1 == p2);
        }
        public static bool operator !=(Pesos p, Dolar d)
        {
            return !(p == d);
        }
        public static bool operator !=(Pesos p, Euro e)
        {
            return !(p == e);
        }

        public static Pesos operator +(Pesos p, Dolar d)
        {
            Pesos aux = new Pesos();
            aux = (Pesos)d;

            return new Pesos(p.GetCantidad + aux.GetCantidad);
        }
        public static Pesos operator +(Pesos p, Euro e)
        {
            return p + (Dolar)e;
        }

        public static Pesos operator -(Pesos p, Dolar d)
        {
            Pesos aux = new Pesos();
            aux = (Pesos)d;

            return new Pesos(p.GetCantidad - aux.cantidad);
        }
        public static Pesos operator -(Pesos p, Euro e)
        {
            return p + (Dolar)e;
        }


        public static double GetCotizacion 
        {
            get
            {
                return Pesos.cotizRespectoDolar;
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
