using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma : Utiles
    {
        public bool soloLapiz;
        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }

        public Goma():base("", 0)
        {

        }
        public Goma(bool soloLapiz, string marca, double precio)
            :base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }

        protected override string UtilesToString()
        {
            return String.Format("{0} - Solo Lapiz: {1} - Precios Cuidados: {2}",
                                    base.UtilesToString(), this.soloLapiz, this.PreciosCuidados);
        }
        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
