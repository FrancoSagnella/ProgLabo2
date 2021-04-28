using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Fabricante
    {
        private string marca;
        private EPais pais;

        public Fabricante(string marca, EPais pais)
        {
            this.marca = marca;
            this.pais = pais;
        }
        public static bool operator ==(Fabricante a, Fabricante b)
        {
            bool ret = false;

            if(a.pais == b.pais && a.marca == b.marca)
            {
                ret = true;
            }

            return ret;
        }
        public static bool operator !=(Fabricante a, Fabricante b)
        {
            return !(a == b);
        }
        public static implicit operator string(Fabricante f)
        {
            return String.Format("Fabricante: {0} - {1}", f.marca, f.pais);
        }
    }
}
