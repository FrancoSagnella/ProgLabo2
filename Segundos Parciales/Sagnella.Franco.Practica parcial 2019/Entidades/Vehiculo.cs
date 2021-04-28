using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected DateTime ingreso;
        private string patente;

        public Vehiculo(string patente)
        {
            this.ingreso = DateTime.Now.AddHours(-3);
            this.Patente = patente;
        }
        public abstract string ConsultarDatos();

        public override string ToString()
        {
            return String.Format("Patente: {0}", this.patente);
        }
        public virtual string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine(this.ToString());
            sb.Append("Ingreso: ");
            sb.AppendLine(this.ingreso.ToString());

            return sb.ToString();
        }
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.Equals(v2);
        }
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
        public string Patente
        {
            get
            {
                return this.patente;
            }
            set
            {
                if(value.Length == 6)
                {
                    this.patente = value;
                }
            }
        }
    }
}
