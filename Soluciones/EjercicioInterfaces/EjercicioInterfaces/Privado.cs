using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Privado : Avion
    {
        protected int valoracionServicio;

        public Privado(double precio, double velocidad, int valoracion)
            :base(precio, velocidad)
        {
            this.valoracionServicio = valoracion;
        }
    }
}
