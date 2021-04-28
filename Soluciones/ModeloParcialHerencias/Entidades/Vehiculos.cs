using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vehiculos
    {
        protected string patente;
        protected byte cantRuedas;
        protected EMarcas marca;

        public Vehiculos(string patente, byte cantRuedas, EMarcas marca)
        {
            this.patente = patente;
            this.cantRuedas = cantRuedas;
            this.marca = marca;
        }
        public string Patente 
        {
            get
            {
                return this.patente;
            }
        }
        public byte CanRuedas 
        {
            get
            {
                return this.cantRuedas;
            }
        }
        public EMarcas Marca
        {
            get
            {
                return this.marca;
            }
        }
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Patente: {0} - ", this.Patente);
            sb.AppendLine();
            sb.AppendFormat("Cantidad de ruedas: {0} - ", this.CanRuedas.ToString());
            sb.AppendLine();
            sb.AppendFormat("Marca: {0} - ", this.Marca.ToString());
            sb.AppendLine();

            return sb.ToString();
        }
        public static bool operator ==(Vehiculos v1, Vehiculos v2)
        {
            bool retorno = false;
            if((v1.Patente == v2.Patente) && (v1.Marca.ToString() == v2.Marca.ToString()))
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Vehiculos v1, Vehiculos v2)
        {
            return !(v1 == v2);
        }
    }
}
