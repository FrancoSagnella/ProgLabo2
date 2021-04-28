using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class CuentaOffShore
    {
        private Cliente dueño;
        private int numeroCuenta;
        private double saldo;

        public CuentaOffShore(Cliente dueño, int numero, double saldoInicial)
        {
            this.dueño = dueño;
            this.numeroCuenta = numero;
            this.saldo = saldoInicial;
        }
        public CuentaOffShore(string nombre, ETipoCliente tipo, int numero, double saldoInicial):this(new Cliente(tipo, nombre), numero, saldoInicial)
        {

        }
        public Cliente Dueño 
        {
            get
            {
                return this.dueño;
            }
        }
        public double Saldo
        {
            get
            {
                return this.saldo;
            }
            set
            {
                this.saldo = value;
            }
        }
        public static explicit operator int(CuentaOffShore cos)
        {
            return cos.numeroCuenta;
        }
        public static bool operator ==(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            bool retorno = false;
            if(((int)cos1 == (int)cos2) && (cos1.Dueño.GetAlias() == cos2.Dueño.GetAlias()))
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(CuentaOffShore cos1, CuentaOffShore cos2)
        {
            return !(cos1 == cos2);
        }
    }
}
