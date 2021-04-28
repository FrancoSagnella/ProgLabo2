using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_22Clases
{
    public class NumeroDecimal
    {
        private double numero;

        private NumeroDecimal(double num)
        {
            this.numero = num;
        }








        public static implicit operator NumeroDecimal(double num)
        {
            return new NumeroDecimal(num);
        }
        public static explicit operator double(NumeroDecimal num)
        {
            return num.numero;
        }








        public static double operator +(NumeroDecimal dec, NumeroBinario bin)
        {
            return (double)dec + (double.Parse(Conversor.BinarioDecimal((string)bin)));
        }
        public static double operator -(NumeroDecimal dec, NumeroBinario bin)
        {
            return (double)dec - (double.Parse(Conversor.BinarioDecimal((string)bin)));
        }
        public static bool operator ==(NumeroDecimal dec, NumeroBinario bin)
        {
            bool ret = false;
            if((double)dec == (double.Parse(Conversor.BinarioDecimal((string)bin))))
            {
                ret = true;
            }
            return ret;
        }
        public static bool operator !=(NumeroDecimal dec, NumeroBinario bin)
        {
            return !(bin == dec);
        }
    }
}
