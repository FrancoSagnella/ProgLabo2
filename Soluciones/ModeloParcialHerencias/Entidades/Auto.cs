using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto : Vehiculos
    {
        protected int cantidadAsientos;

        public Auto(string patente, byte cantRuedas, EMarcas marca, int cantidadAsientos)
            : base(patente, cantRuedas, marca)
        {
            this.cantidadAsientos = cantidadAsientos;
        }
        public int CantidadAsientos
        {
            get
            {
                return this.cantidadAsientos;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendFormat("Cantidad de asientos: {0}", this.CantidadAsientos);
            sb.AppendLine();

            return sb.ToString();
        } 
    }
}
