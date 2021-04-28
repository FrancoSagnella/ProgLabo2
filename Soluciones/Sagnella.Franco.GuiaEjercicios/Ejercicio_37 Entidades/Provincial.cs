using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_37_Entidades
{
    public class Provincial : Llamada
    {
        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3
        }

        protected Franja franjaHoraria;

        public Provincial(Franja miFranja, Llamada llamada)
            :this(llamada.NroOrigen, miFranja, llamada.Duracion, llamada.NroDestino)
        {
        }
        public Provincial(string origen, Franja miFranja, float duracion, string destino)
            :base(duracion, destino, origen)
        {
            this.franjaHoraria = miFranja;
        }
        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.Append("Costo de la llamada: ");
            sb.AppendLine(this.CostoLlamada.ToString());
            sb.Append("Franja horaria: ");
            sb.AppendLine(this.franjaHoraria.ToString());

            return sb.ToString();
        }
        private float CalcularCosto()
        {
            float ret = 0;
            switch (this.franjaHoraria)
            {
                case Franja.Franja_1:
                    ret = this.duracion * (float)0.99;
                    break;

                case Franja.Franja_2:
                    ret = this.duracion * (float)1.25;
                    break;

                case Franja.Franja_3:
                    ret = this.duracion * (float)0.66;
                    break;
            }
            return ret;
        }
        public float CostoLlamada
        {
            get
            {
                return this.CalcularCosto();
            }
        }
    }
}
