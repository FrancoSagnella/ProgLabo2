using PrestamosPersonales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoPesos : Prestamo
    {
        private float porcentajeInteres;

        public PrestamoPesos(float monto, DateTime vencimiento, float interes)
            :base(monto, vencimiento)
        {
            this.porcentajeInteres = interes;
        }
        public PrestamoPesos(Prestamo p, float interes)
            :this(p.Monto, p.Vencimiento, interes)
        {
        }
        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }
        private float CalcularInteres()
        {
            return ((this.monto * this.porcentajeInteres) / 100);
        }
        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDeDias = new TimeSpan();
            diferenciaDeDias = nuevoVencimiento - this.vencimiento;

            if (diferenciaDeDias.Days > 0)
            {
                this.porcentajeInteres += ((float)0.25 * diferenciaDeDias.Days);
                this.Vencimiento = nuevoVencimiento;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendFormat("Porcentaje de interes: {0}\n", this.porcentajeInteres);
            sb.AppendFormat("Interes: {0}", this.Interes);

            return sb.ToString();
        }
    }
}
