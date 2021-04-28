using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        private ConsoleColor color;
        private static int valorHora;

        static Automovil()
        {
            Automovil.valorHora = 50;
        }
        public Automovil(string patente, ConsoleColor color):base(patente)
        {
            this.color = color;
        }
        public Automovil(string patente, ConsoleColor color, int valorHora):this(patente, color)
        {
            Automovil.valorHora = valorHora;
        }
        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ImprimirTicket());
            sb.Append("Color: ");
            sb.AppendLine(this.color.ToString());
            sb.Append("Valor por hora: ");
            sb.AppendLine(Automovil.valorHora.ToString());
            sb.Append("Costo de estadia: ");
            sb.AppendLine(((DateTime.Now.Hour - base.ingreso.Hour) * Automovil.valorHora).ToString());

            return sb.ToString();
        }
        public override string ConsultarDatos()
        {
            return this.ImprimirTicket();
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Automovil)
            {
                if (this.Patente == ((Vehiculo)obj).Patente)
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
