using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_37_Entidades
{
    public class Local : Llamada
    {
        protected float costo;

        public Local(Llamada llamada, float costo)
            :this(llamada.NroOrigen, llamada.Duracion, llamada.NroDestino, costo)
        {
        }
        public Local(string origen, float duracion, string destino, float costo)
            :base(duracion, destino, origen)
        {
            this.costo = costo;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.Append("Costo de la llamada: ");
            sb.AppendLine(this.CostoLlamada.ToString());

            return sb.ToString();
        }
        private float CarlcularCosto()
        {
            return this.duracion * this.costo;
        }
        public float CostoLlamada
        {
            get
            {
                return this.CarlcularCosto();
            }
        } 
    }
}
