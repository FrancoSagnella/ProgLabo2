using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public Perro(string nombre, string raza)
            :base(nombre, raza)
        {
            this.edad = 0;
            this.esAlfa = false;
        }
        public Perro(string nombre, string raza, int edad, bool esAlfa)
            :this(nombre, raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }
        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            if (this.esAlfa)
            {
                sb.AppendFormat("Perro - {0}, alfa de la manada, edad {1}", base.DatosCompletos(), (int)this);
            }
            else
            {
                sb.AppendFormat("Perro - {0}, edad {1}", base.DatosCompletos(), (int)this);
            }
            return sb.ToString();
        }
        public static bool operator ==(Perro p1, Perro p2)
        {
            bool retorno = false;
            if ((Mascota)p1 == (Mascota)p2 && (int)p1 == (int)p2)
            {
                retorno = true;
            }
            return retorno;
        }
        public static explicit operator int(Perro p)
        {
            return p.edad;
        }
        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if(obj is Perro)
            {
                retorno = this == (Perro)obj;
            }
            return retorno;
        }
        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
