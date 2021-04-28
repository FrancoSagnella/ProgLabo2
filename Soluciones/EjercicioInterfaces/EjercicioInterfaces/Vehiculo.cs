using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public abstract class Vehiculo
    {
        protected double precio;

        public Vehiculo(double precio)
        {
            this.precio = precio;
        }
        public virtual void MostrarPrecio()
        {
            Console.WriteLine(this.precio);
        }
    }
}
