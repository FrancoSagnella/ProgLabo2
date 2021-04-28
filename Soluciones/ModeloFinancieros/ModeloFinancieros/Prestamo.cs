using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public abstract class Prestamo
    {
        protected float monto;
        protected DateTime vencimiento;

        public Prestamo(float monto, DateTime vencimiento)
        {
            this.monto = monto;
            this.Vencimiento = vencimiento;
        }
        public float Monto
        {
            get
            {
                return this.monto;
            }
        }
        public DateTime Vencimiento 
        {
            get 
            { 
                return this.vencimiento; 
            }
            set
            { 
                if(DateTime.Compare(value, DateTime.Now) > 0)
                {
                    this.vencimiento = value;
                }
                else
                {
                    this.vencimiento = DateTime.Now;
                }
            }
        }
        public static int OrdenrPorFecha(Prestamo p1, Prestamo p2)
        {
            return DateTime.Compare(p1.vencimiento.Date, p2.vencimiento.Date);
        }
        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Monto: {0}\n", this.monto);
            sb.AppendFormat("Vencimiento: {0}\n", this.vencimiento.Date.ToString("dd-MM-yyyy"));

            return sb.ToString();
        }
    }
}
