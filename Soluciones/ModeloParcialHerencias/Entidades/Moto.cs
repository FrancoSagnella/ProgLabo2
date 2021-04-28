using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculos
    {
        protected float cilindrada;
        public Moto(string patente, byte cantRuedas, EMarcas marca, float cilindrada)
            : base(patente, cantRuedas, marca)
        {
            this.cilindrada = cilindrada;
        }
        public float Cilindrada
        {
            get
            {
                return this.cilindrada;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendFormat("La cilindrada es: {0}", this.Cilindrada);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
