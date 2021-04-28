using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_37_Entidades
{
    public class Centralita
    {
        private List<Llamada> listaLlamadas;
        protected string razonSocial;

        public float GananciasLocal
        {
            get
            {
                float ret = 0;
                foreach (Llamada item in this.listaLlamadas)
                {
                    if(item is Local)
                    {
                        ret += ((Local)item).CostoLlamada;
                    }
                }
                return ret;
            }
        }
        public float GananciasProvincial
        {
            get
            {
                float ret = 0;
                foreach (Llamada item in this.listaLlamadas)
                {
                    if (item is Provincial)
                    {
                        ret += ((Provincial)item).CostoLlamada;
                    }
                }
                return ret;
            }
        }
        public float GananciasTotal
        {
            get
            {
                float ret = 0;
                foreach (Llamada item in this.listaLlamadas)
                {
                    if (item is Provincial)
                    {
                        ret += ((Provincial)item).CostoLlamada;
                    }
                    else if (item is Local)
                    {
                        ret += ((Local)item).CostoLlamada;
                    }
                }
                return ret;
            }
        }
        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaLlamadas;
            }
        }
        public Centralita()
        {
            this.listaLlamadas = new List<Llamada>();
        }
        public Centralita(string nombreEmpresa)
            :this()
        {
            this.razonSocial = nombreEmpresa;
        }
        private float CalcularGanancia(TipoLlamada tipo)
        {
            float ret = 0;
            switch (tipo)
            {
                case TipoLlamada.Local:
                    ret = this.GananciasLocal;
                    break;

                case TipoLlamada.Provincial:
                    ret = this.GananciasProvincial;
                    break;

                case TipoLlamada.Todas:
                    ret = this.GananciasTotal;
                    break;
            }
            return ret;
        }
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Razon Social: ");
            sb.AppendLine(this.razonSocial);
            sb.Append("Ganancia total: ");
            sb.AppendLine(this.CalcularGanancia(TipoLlamada.Todas).ToString());
            sb.Append("ganancia por llamadas Locales: ");
            sb.AppendLine(this.CalcularGanancia(TipoLlamada.Local).ToString());
            sb.Append("Ganancia por llamads Provinciales: ");
            sb.AppendLine(this.CalcularGanancia(TipoLlamada.Provincial).ToString());
            sb.AppendLine("****************LLAMADAS***************");

            foreach(Llamada item in this.listaLlamadas)
            {
                sb.AppendLine(item.Mostrar());
            }

            return sb.ToString();
        }
        public void OrdenarLlamadas()
        {
            Comparison<Llamada> comparison = Llamada.OrdenarPorDuracion;
            this.listaLlamadas.Sort(comparison);
        }
    }
}
