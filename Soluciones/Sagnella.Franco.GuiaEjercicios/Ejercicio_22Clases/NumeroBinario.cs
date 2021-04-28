using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_22Clases
{
    public class NumeroBinario
    {
        private string numero;

        private NumeroBinario(string num)
        {
            this.numero = num;
        }





        public static implicit operator NumeroBinario(string num)
        {
            return new NumeroBinario(num);
        }
        public static explicit operator string(NumeroBinario num)
        {
            return num.numero;
        }







        
        public static string operator +(NumeroBinario bin, NumeroDecimal dec)
        {
            double aux = dec + bin;
            return Conversor.DecimalBinario(aux);
        }
        public static string operator -(NumeroBinario bin, NumeroDecimal dec)
        {
            double aux = dec - bin;
            return Conversor.DecimalBinario(aux);
        }
        public static bool operator ==(NumeroBinario bin, NumeroDecimal dec)
        {
            return dec == bin;
        }
        public static bool operator !=(NumeroBinario bin, NumeroDecimal dec)
        {
            return !(bin == dec);
        }
    }
}
