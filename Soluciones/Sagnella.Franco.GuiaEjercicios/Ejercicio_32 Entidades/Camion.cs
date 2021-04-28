using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_32_Entidades
{
    public class Camion : VehiculoTerrestre 
    {
        private short cantMarchas;
        private int pesoCarga;

        public Camion(short cantRuedas, short cantPuertas, Colores color, short cantMarchas, int pesoCarga)
            :base(cantRuedas, cantPuertas, color)
        {
            this.cantMarchas = cantMarchas;
            this.pesoCarga = pesoCarga;
        }
    }
}
