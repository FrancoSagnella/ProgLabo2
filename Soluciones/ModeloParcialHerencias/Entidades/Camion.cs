using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camion : Vehiculos
    {
        protected float tara;
        public Camion(string patente, byte cantRuedas, EMarcas marca, float tara)
            : base(patente, cantRuedas, marca)
        {
            this.tara = tara;
        }
        public float Tara
        {
            get
            {
                return this.tara;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendFormat("La tara: {0}", this.Tara);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
