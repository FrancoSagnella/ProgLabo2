using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PickUp : Vehiculo
    {
        private string modelo;
        private static int valorHora;

        static PickUp()
        {
            PickUp.valorHora = 70;
        }
        public PickUp(string patente, string modelo) : base(patente)
        {
            this.modelo = modelo;
        }
        public PickUp(string patente, string modelo, int valorHora):this(patente, modelo)
        {
            PickUp.valorHora = valorHora;
        }
        public override string ImprimirTicket()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.ImprimirTicket());
            sb.Append("Modelo: ");
            sb.AppendLine(this.modelo);
            sb.Append("Valor por hora: ");
            sb.AppendLine(PickUp.valorHora.ToString());
            sb.Append("Costo de estadia: ");
            sb.AppendLine(((DateTime.Now.Hour - base.ingreso.Hour) * PickUp.valorHora).ToString());

            return sb.ToString();
        }
        public override string ConsultarDatos()
        {
            return this.ImprimirTicket();
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is PickUp)
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
