using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Mascota
    {
        private string nombre;
        private string raza;

        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }

        public string Raza
        {
            get
            {
                return this.raza;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        protected abstract string Ficha();

        protected virtual string DatosCompletos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} - {1}", this.nombre, this.raza);

            return sb.ToString();
        }
        public static bool operator ==(Mascota m1, Mascota m2)
        {
            bool retorno = false;
            if(m1.nombre == m2.nombre && m1.raza == m2.raza)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }
    }
}
