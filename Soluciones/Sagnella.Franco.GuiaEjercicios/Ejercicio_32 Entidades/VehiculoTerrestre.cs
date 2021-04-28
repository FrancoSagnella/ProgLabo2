using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_32_Entidades
{
    public class VehiculoTerrestre
    {
        protected short cantRuedas;
        protected short cantPuertas;
        protected Colores color;

        public VehiculoTerrestre(short cantRuedas, short cantPuertas, Colores color)
        {
            this.cantPuertas = cantPuertas;
            this.cantRuedas = cantRuedas;
            this.color = color;
        }
    }
}
