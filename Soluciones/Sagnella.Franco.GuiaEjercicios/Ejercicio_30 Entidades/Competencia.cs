using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_30_Entidades
{
    public class Competencia
    {
        private short cantCompetidores;
        private short cantVueltas;
        public List<AutoF1> competidores;

        private Competencia()
        {
            this.competidores = new List<AutoF1>();
        }
        public Competencia(short cantCompetidores, short cantVueltas) : this()
        {
            this.cantVueltas = cantVueltas;
            this.cantCompetidores = cantCompetidores;
        }

        public static bool operator +(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            Random aux = new Random();
            if(c.cantCompetidores != c.competidores.Count())
            {
                if(c != a)
                {
                    a.CantCombustible = (short)aux.Next(15, 100);
                    a.EnCompetencia = true;
                    a.VueltasRestantes = c.cantVueltas;
                    c.competidores.Add(a);
                    retorno = true;
                }
            }
            return retorno;
        }
        public static bool operator -(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            if (c == a)
            {
                a.CantCombustible = 0;
                a.EnCompetencia = false;
                a.VueltasRestantes = 0;
                c.competidores.Remove(a);
                retorno = true;
            }
            return retorno;
        }
        public static bool operator ==(Competencia c, AutoF1 a)
        {
            bool retorno = false;
            foreach(AutoF1 item in c.competidores)
            {
                if(item == a)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Competencia c, AutoF1 a)
        {
            return !(c == a);
        }
    }
}
