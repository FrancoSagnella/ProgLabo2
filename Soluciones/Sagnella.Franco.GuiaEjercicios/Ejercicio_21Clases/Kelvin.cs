using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_21Clases
{
    public class Kelvin
    {
        private double cantidad;

        public Kelvin():this(0)
        {

        }
        public Kelvin(double cantidad)
        {
            this.cantidad = cantidad;
        }

        public static explicit operator Celcius(Kelvin k)
        {
            Fahrenheit f = (Fahrenheit)k;
            return (Celcius)f;
        }
        public static explicit operator Fahrenheit(Kelvin k)
        {
            return new Fahrenheit(k.GetCantidad * 9/5 - 459.67);
        }
        public static implicit operator Kelvin(double cant)
        {
            return new Kelvin(cant);
        }
        public static Kelvin operator +(Kelvin k, Celcius c)
        {
            return k + (Fahrenheit)c;
        }
        public static Kelvin operator +(Kelvin k, Fahrenheit f)
        {
            Kelvin k2 = (Kelvin)f;
            return new Kelvin(k.GetCantidad + k2.GetCantidad);
        }
        public static Kelvin operator -(Kelvin k, Celcius c)
        {
            return k + (Fahrenheit)c;
        }
        public static Kelvin operator -(Kelvin k, Fahrenheit f)
        {
            Kelvin k2 = (Kelvin)f;
            return new Kelvin(k.GetCantidad + k2.GetCantidad);
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
