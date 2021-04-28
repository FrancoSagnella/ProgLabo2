using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public override bool PreciosCuidados
        {
            get
            {
                return false;
            }
        }

        public Sacapunta():base("", 0)
        {

        }
        public Sacapunta(bool deMetal, double precio, string marca)
            :base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        protected override string UtilesToString()
        {
            return String.Format("{0} - De Metal: {1} - Precios Cuidados: {2}", 
                                    base.UtilesToString(), this.deMetal, this.PreciosCuidados);
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
