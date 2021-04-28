using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_32_Entidades
{
    public class Automovil : VehiculoTerrestre
    {
        private short cantMarchas;
        private short cantPasajeros;

        public Automovil(short cantRuedas, short cantPuertas, Colores color, short cantMarchas, short cantPasajeros)
            :base(cantRuedas, cantPuertas, color)
        {
            this.cantMarchas = cantMarchas;
            this.cantPasajeros = cantPasajeros;
        }
    }
}
