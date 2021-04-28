using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21Clases
{
    public class Fahrenheit
    {
        private double cantidad;
        public Fahrenheit() : this(0)
        {

        }
        public Fahrenheit(double cantidad)
        {
            this.cantidad = cantidad;
        }
        public static explicit operator Celcius(Fahrenheit f)
        {
            return new Celcius((f.GetCantidad - 32) * 5 / 9);
        }
        public static explicit operator Kelvin(Fahrenheit f)
        {
            return new Kelvin((f.GetCantidad + 459.67) * 5 / 9);
        }
        public static implicit operator Fahrenheit(double cant)
        {
            return new Fahrenheit(cant);
        }
        public static Fahrenheit operator +(Fahrenheit f, Celcius c)
        {
            Fahrenheit f2 = (Fahrenheit)c;
            return new Fahrenheit(f.GetCantidad + f2.GetCantidad);
        }
        public static Fahrenheit operator +(Fahrenheit f, Kelvin k)
        {
            return f + (Celcius)k;
        }
        public static Fahrenheit operator -(Fahrenheit f, Celcius c)
        {
            Fahrenheit f2 = (Fahrenheit)c;
            return new Fahrenheit(f.GetCantidad - f2.GetCantidad);
        }
        public static Fahrenheit operator -(Fahrenheit f, Kelvin k)
        {
            return f - (Celcius)k;
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
