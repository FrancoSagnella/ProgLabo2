using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estacionamiento
    {
        private int espacioDisponible;
        private string nombre;
        private List<Vehiculo> vehiculos;

        private Estacionamiento()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Estacionamiento(string nombre, int espacioDisponible):this()
        {
            this.nombre = nombre;
            this.espacioDisponible = espacioDisponible;
        }
        public static explicit operator string(Estacionamiento e)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\n**********Estacionamiento**********\n");
            sb.Append("Nombre: ");
            sb.AppendLine(e.nombre);
            sb.Append("Espacio disponible: ");
            sb.AppendLine(e.espacioDisponible.ToString());
            sb.AppendLine("\n**********Vehiculos**********\n");
            
            foreach(Vehiculo item in e.vehiculos)
            {
                sb.AppendLine(item.ConsultarDatos());
            }

            return sb.ToString();
        }
        public static bool operator ==(Estacionamiento e, Vehiculo v)
        {
            bool retorno = false;
            foreach(Vehiculo item in e.vehiculos)
            {
                if(item == v)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Estacionamiento e, Vehiculo v)
        {
            return !(e == v);
        }
        public static Estacionamiento operator +(Estacionamiento e, Vehiculo v)
        {
            if(e != v && v.Patente != null && e.espacioDisponible > e.vehiculos.Count)
            {
                e.vehiculos.Add(v);
            }
            return e;
        }
        public static string operator -(Estacionamiento e, Vehiculo v)
        {
            string retorno = "El vehiculo no es parte del estacionamiento";
            if (e == v)
            {
                retorno = v.ImprimirTicket();
                e.vehiculos.Remove(v);
            }
            return retorno;
        }
    }
}
