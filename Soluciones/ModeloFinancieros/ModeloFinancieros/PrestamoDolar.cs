using PrestamosPersonales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar : Prestamo
    {
        private PeriodicidadDePagos periodicidad;

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad)
            :base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }
        public PrestamoDolar(Prestamo p, PeriodicidadDePagos periodicidad)
            :this(p.Monto, p.Vencimiento, periodicidad)
        {
        }
        public float Interes
        {
            get
            {
                return this.CalcularInteres();
            }
        }
        public PeriodicidadDePagos Periodicidad
        {
            get
            {
                return this.periodicidad;
            }
        }
        private float CalcularInteres()
        {
            return ((this.monto * (int)this.periodicidad) / 100);
        }
        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            TimeSpan diferenciaDeDias = new TimeSpan();
            diferenciaDeDias = nuevoVencimiento - this.vencimiento;

            if(diferenciaDeDias.Days > 0)
            {
                this.monto += ((float)2.5 * diferenciaDeDias.Days);
                this.Vencimiento = nuevoVencimiento;
            }
        }
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.Mostrar());
            sb.AppendFormat("Periodicidad de pago: {0}\n", this.periodicidad.ToString());
            sb.AppendFormat("Interes: {0}", this.Interes);

            return sb.ToString();
        }
    }
}
