using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_30_Entidades
{
    public class AutoF1
    {
        private short cantCombustible;
        private bool enCompetencia;
        private string escuderia;
        private short numero;
        private short vueltasRestantes;

        public AutoF1(short numero, string escuderia)
        {
            this.numero = numero;
            this.escuderia = escuderia;
        }
        public short CantCombustible 
        {
            get
            {
                return this.cantCombustible;
            }
            set
            {
                this.cantCombustible = value;
            }
        }
        public bool EnCompetencia
        {
            get
            {
                return this.enCompetencia;
            }
            set
            {
                this.enCompetencia = value;
            }
        }
        public short VueltasRestantes
        {
            get
            {
                return this.vueltasRestantes;
            }
            set
            {
                this.vueltasRestantes = value;
            }
        }
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Escuderia: ");
            sb.AppendLine(this.escuderia);
            sb.Append("Numero: ");
            sb.AppendLine(this.numero.ToString());
            sb.Append("En competencia: ");
            sb.AppendLine(this.enCompetencia.ToString());
            sb.Append("Cantidad de combustible: ");
            sb.AppendLine(this.cantCombustible.ToString());
            sb.Append("Vueltas restantes: ");
            sb.AppendLine(this.vueltasRestantes.ToString());

            return sb.ToString();
        }
        public static bool operator ==(AutoF1 a1, AutoF1 a2)
        {
            bool retorno = false;
            if(a1.numero == a2.numero && a1.escuderia == a2.escuderia)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(AutoF1 a1, AutoF1 a2)
        {
            return !(a1 == a2);
        }
    }
}
