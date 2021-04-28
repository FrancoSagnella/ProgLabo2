using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21Clases
{
    public class Celcius
    {
        private double cantidad;
        public Celcius() : this(0)
        {

        }
        public Celcius(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public static explicit operator Kelvin(Celcius c)
        {
            Fahrenheit f = (Fahrenheit)c;
            return (Kelvin)f;
        }
        public static explicit operator Fahrenheit(Celcius c)
        {
            return new Fahrenheit(c.GetCantidad * 9 / 5 + 32);
        }
        public static implicit operator Celcius(double cant)
        {
            return new Celcius(cant);
        }
        public static Celcius operator +(Celcius c, Kelvin k)
        {
            return c + (Fahrenheit)k;
        }
        public static Celcius operator +(Celcius c, Fahrenheit f)
        {
            Celcius c2 = (Celcius)f;
            return new Celcius(c.GetCantidad + c2.GetCantidad);
        }
        public static Celcius operator -(Celcius c, Kelvin k)
        {
            return c - (Fahrenheit)k;
        }
        public static Celcius operator -(Celcius c, Fahrenheit f)
        {
            Celcius c2 = (Celcius)f;
            return new Celcius(c.GetCantidad - c2.GetCantidad);
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
