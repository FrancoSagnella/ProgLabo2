using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_37_Entidades
{
    public enum TipoLlamada
        {
            Local,
            Provincial,
            Todas
        }
    public class Llamada
    {
        
        protected float duracion;
        protected string nroDestino;
        protected string nroOrigen;

        public Llamada(float duracion, string nroDestino, string nroOrigen)
        {
            this.duracion = duracion;
            this.nroDestino = nroDestino;
            this.nroOrigen = nroOrigen;
        }
        public float Duracion
        {
            get
            {
                return this.duracion;
            }
        }
        public string NroDestino
        {
            get
            {
                return this.nroDestino;
            }
        }
        public string NroOrigen
        {
            get
            {
                return this.nroOrigen;
            }
        }
        public static int OrdenarPorDuracion(Llamada l1, Llamada l2)
        {
            return String.Compare(l1.duracion.ToString(), l2.duracion.ToString());
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Duracion: ");
            sb.AppendLine(this.duracion.ToString());
            sb.Append("nroOrigen: ");
            sb.AppendLine(this.nroOrigen.ToString());
            sb.Append("nroDestino: ");
            sb.AppendLine(this.nroDestino.ToString());

            return sb.ToString();
        }
    }
}
