using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public class Avion : Vehiculo , IAfip
    {
        protected double velocidadMaxima;

        public Avion(double precio, double velocidadMaxima) : base(precio)
        {
            this.velocidadMaxima = velocidadMaxima;
        }

        double IAfip.CalcularImpuesto()
        {
            return this.precio *= 0.33;
        }
    }
}
