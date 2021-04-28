using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Comercial : Avion
    {
        protected int cantPasajeros;

        public Comercial(double precio, double velocidad, int cant)
            :base(precio, velocidad)
        {
            this.cantPasajeros = cant;
        }
    }
}
