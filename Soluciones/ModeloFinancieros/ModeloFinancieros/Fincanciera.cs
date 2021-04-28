using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        private List<Prestamo> listaPrestamos;
        private string razonSocial;

        private Financiera()
        {
            this.listaPrestamos = new List<Prestamo>();
        }
        public Financiera(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }

        public float InteresesEnDolares
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Dolares);
            }
        }
        public float InteresesEnPesos
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Pesos);
            }
        }
        public float InteresesTotales
        {
            get
            {
                return this.CalcularInteresGanado(TipoDePrestamo.Todos);
            }
        }
        public List<Prestamo> ListaPrestamo
        {
            get
            {
                return this.listaPrestamos;
            }
        }
        public string RazonSocial
        {
            get
            {
                return this.razonSocial;
            }
        }
        public static explicit operator string(Financiera f)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Razon Social: {0}\n", f.razonSocial);
            sb.AppendFormat("Intereses totales ganados: {0}\n", f.InteresesTotales);
            sb.AppendFormat("Intereses por pesos ganados: {0}\n", f.InteresesEnPesos);
            sb.AppendFormat("Intereses por dolar ganados: {0}\n", f.InteresesEnDolares);
            sb.AppendLine();

            f.OrdenarPrestamos();

            foreach(Prestamo item in f.listaPrestamos)
            {
                sb.AppendLine(item.Mostrar());
                sb.AppendLine();
            }

            return sb.ToString();
        }
        public void OrdenarPrestamos()
        {
            Comparison<Prestamo> comparison = Prestamo.OrdenrPorFecha;
            this.listaPrestamos.Sort(comparison);
        }
        private float CalcularInteresGanado(TipoDePrestamo tipo)
        {
            float suma = 0;
            foreach(Prestamo item in this.listaPrestamos)
            {
                switch (tipo)
                {
                    case TipoDePrestamo.Dolares:
                        if(item is PrestamoDolar)
                        {
                            suma += ((PrestamoDolar)item).Interes;
                        }
                        break;
                    case TipoDePrestamo.Pesos:
                        if (item is PrestamoPesos)
                        {
                            suma += ((PrestamoPesos)item).Interes;
                        }
                        break;
                    default:
                        if (item is PrestamoDolar)
                        {
                            suma += ((PrestamoDolar)item).Interes;
                        }
                        if (item is PrestamoPesos)
                        {
                            suma += ((PrestamoPesos)item).Interes;
                        }
                        break;
                }
            }
            return suma;
        }
        public static string Mostrar(Financiera f)
        {
            return (string)f;
        }
        public static Financiera operator +(Financiera f, Prestamo p)
        {
            if(f != p)
            {
                f.listaPrestamos.Add(p);
            }
            return f;
        }
        public static bool operator ==(Financiera f, Prestamo p)
        {
            bool ret = false;
            foreach(Prestamo item in f.listaPrestamos)
            {
                if(item == p)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        public static bool operator !=(Financiera f, Prestamo p)
        {
            return !(f == p);
        }
    }
}
