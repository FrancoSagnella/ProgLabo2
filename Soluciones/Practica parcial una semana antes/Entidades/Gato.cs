using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Gato : Mascota
    {
        public Gato(string nombre, string raza):base(nombre, raza)
        {

        }
        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("gato - {0}", base.DatosCompletos());

            return sb.ToString();
        }
        public static bool operator ==(Gato g1, Gato g2)
        {
            bool retorno = false;
            if((Mascota)g1 == (Mascota)g2)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Gato)
            {
                retorno = this == (Gato)obj;
            }
            return retorno;
        }
        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
