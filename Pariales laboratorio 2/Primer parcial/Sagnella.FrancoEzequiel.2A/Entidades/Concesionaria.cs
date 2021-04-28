using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Concesionaria
    {
        private int capacidad;
        private List<Vehiculo> vehiculos;

        private Concesionaria()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        private Concesionaria(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }
        public double PrecioDeAuto
        {
            get
            {
                float ret = 0;
                foreach (Vehiculo item in this.vehiculos)
                {
                    if (item is Auto)
                    {
                        ret += (float)((Auto)item);
                    }
                }
                return ret;
            }
        }
        public double PrecioDeMoto
        {
            get
            {
                float ret = 0;
                foreach (Vehiculo item in this.vehiculos)
                {
                    if (item is Moto)
                    {
                        ret += (Moto)item;
                    }
                }
                return ret;
            }
        }
        public double PrecioTotal
        {
            get
            {
                return this.PrecioDeAuto + this.PrecioDeMoto;
            }
        }
        public static string Mostrar(Concesionaria c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Capacidad: {0}\n", c.capacidad);
            sb.AppendFormat("Total por autos: {0}\n", c.ObtenerPrecio(EVehiculo.PrecioDeAuto));
            sb.AppendFormat("Total por motos: {0}\n", c.ObtenerPrecio(EVehiculo.PrecioDeMoto));
            sb.AppendFormat("Total: {0}\n", c.ObtenerPrecio(EVehiculo.Todos));

            sb.AppendLine("************Vehiculos************");
            foreach(Vehiculo item in c.vehiculos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        private double ObtenerPrecio(EVehiculo tipoVehiculo)
        {
            double ret;

            switch (tipoVehiculo)
            {
                case EVehiculo.PrecioDeAuto:

                   ret = this.PrecioDeAuto;
                   break;

                case EVehiculo.PrecioDeMoto:

                   ret = this.PrecioDeMoto;
                   break;

                default:

                   ret = this.PrecioTotal;
                   break;
            }
            return ret;
        }
        public static implicit operator Concesionaria(int capacidad)
        {
            return new Concesionaria(capacidad);
        }
        public static bool operator ==(Concesionaria c, Vehiculo v)
        {
            bool ret = false;

            foreach(Vehiculo item in c.vehiculos)
            {
                if (item.Equals(v))
                {
                    ret = true;
                    break;
                }
            }

            return ret;
        }
        public static bool operator !=(Concesionaria c, Vehiculo v)
        {
            return !(c == v);
        }
        public static Concesionaria operator +(Concesionaria c, Vehiculo v)
        {
            if(c.vehiculos.Count() < c.capacidad)
            {
                if (c != v)
                {
                    c.vehiculos.Add(v);
                }
                else
                {
                    Console.WriteLine("El vehiculo ya esta en la concesionaria!");
                }
            }
            else
            {
                Console.WriteLine("No hay mas lugar en la concesionaria!");
            }
            return c;
        }
    }
}
