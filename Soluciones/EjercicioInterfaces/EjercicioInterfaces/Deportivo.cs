using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Deportivo : Auto , IAfip
    {
        protected int caballosDeFuerza;

        public Deportivo(double precio, string patente, int caballosFuerza)
            :base(precio, patente)
        {
            this.caballosDeFuerza = caballosFuerza;
        }

        double IAfip.CalcularImpuesto()
        {
            return this.precio *= 0.28;
        }
    }
}
