using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        private int cilindrada;
        private short ruedas;
        private static int valorHora;

        static Moto()
        {
            Moto.valorHora = 30;
        }
        public Moto(string patente, int cilindrada):base(patente)
        {
            this.ruedas = 2;
            this.cilindrada = cilindrada;
        }
        public Moto(string patente, int cilindrada, short ruedas):this(patente, cilindrada)
        {
            this.ruedas = ruedas;
        }
        public Moto(string patente, int cilindrada, short ruedas, int valorHora):this(patente, cilindrada, ruedas)
        {
            Moto.valorHora = valorHora;
        }
        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ImprimirTicket());
            sb.Append("Cilindrada: ");
            sb.AppendLine(this.cilindrada.ToString());
            sb.Append("Cantidad de ruedas: ");
            sb.AppendLine(this.ruedas.ToString());
            sb.Append("Valor por hora: ");
            sb.AppendLine(Moto.valorHora.ToString());
            sb.Append("Costo de estadia: ");
            sb.AppendLine(((DateTime.Now.Hour - base.ingreso.Hour) * Moto.valorHora).ToString());

            return sb.ToString();
        }
        public override string ConsultarDatos()
        {
            return this.ImprimirTicket();
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Moto)
            {
                if(this.Patente == ((Vehiculo)obj).Patente)
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
