using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Familiar : Auto
    {
        protected int cantAsientos;

        public Familiar(double precio, string patente, int cantAsientos)
            :base(precio, patente)
        {
            this.cantAsientos = cantAsientos;
        }
    }
}
