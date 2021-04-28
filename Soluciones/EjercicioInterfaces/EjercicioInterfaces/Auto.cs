using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public abstract class Auto : Vehiculo
    {
        protected string patente;

        public Auto(double precio, string patente):base(precio)
        {
            this.patente = patente;
        }
        public virtual void MostrarPatente()
        {
            Console.WriteLine(this.patente);
        }
    }
}
