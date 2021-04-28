using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ParaisoFiscal
    {
        private List<CuentaOffShore> listadoCuentas;
        private EParaisosFiscales lugar;
        public static int cantidadCuentas;
        public static DateTime fechaInicioActividades;

        static ParaisoFiscal()
        {
            cantidadCuentas = 0;
            fechaInicioActividades = DateTime.Now;
        }
        private ParaisoFiscal()
        {
            this.listadoCuentas = new List<CuentaOffShore>();
        }
        private ParaisoFiscal(EParaisosFiscales lugar):this()
        {
            this.lugar = lugar;
        }
        public void MostrarParaiso()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();

            sb.Append("Fecha de inicio: ");
            sb.AppendLine(ParaisoFiscal.fechaInicioActividades.ToString());
            sb.Append("Locacion: ");
            sb.AppendLine(this.lugar.ToString());
            sb.Append("Cantidad de cuentas: ");
            sb.AppendLine(ParaisoFiscal.cantidadCuentas.ToString());

            sb.AppendLine("******************Cuentas Off Shore*****************");

            foreach(CuentaOffShore item in this.listadoCuentas)
            {
                sb.AppendLine(Cliente.RetornarDatos(item.Dueño));

                sb.Append("Numero de cuenta: ");
                sb.AppendLine(((int)item).ToString());
                sb.Append("Saldo: ");
                sb.AppendLine(item.Saldo.ToString());
                sb.AppendLine();
            }

            Console.Write(sb);
        }
        public static implicit operator ParaisoFiscal(EParaisosFiscales epf)
        {
            return new ParaisoFiscal(epf);
        }
        public static bool operator ==(ParaisoFiscal pf, CuentaOffShore cos)
        {
            bool retorno = false;
            foreach(CuentaOffShore item in pf.listadoCuentas)
            {
                if(item == cos)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(ParaisoFiscal pf, CuentaOffShore cos)
        {
            return !(pf == cos);
        }
        public static ParaisoFiscal operator +(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if(pf == cos)
            {
                //pf.listadoCuentas[pf.listadoCuentas.IndexOf(cos)].Saldo += cos.Saldo;
                for(int i = 0; i < pf.listadoCuentas.Count; i++)
                {
                    if(pf.listadoCuentas[i] == cos)
                    {
                        pf.listadoCuentas[i].Saldo += cos.Saldo;
                        break;
                    }
                }
                Console.WriteLine("Se actualizo el saldo de la cuenta");
            }
            else
            {
                ParaisoFiscal.cantidadCuentas++;
                pf.listadoCuentas.Add(cos);
                Console.WriteLine("Se agrego la cuenta al paraiso fiscal");
            }
            return pf;
        }
        public static ParaisoFiscal operator -(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if(pf == cos)
            {
                pf.listadoCuentas.Remove(cos);
                ParaisoFiscal.cantidadCuentas--;
                Console.WriteLine("Se elimino la cuenta del paraiso fiscal");
            }
            else
            {
                Console.WriteLine("La cuenta no existia en el paraiso fiscal");
            }
            return pf;
        }
    }
}
