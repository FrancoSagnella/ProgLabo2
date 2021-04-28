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
            get { return false; }
        }

        public Sacapunta() : this(false, 0, "")
        {

        }
        public Sacapunta(bool deMetal, double precio, string marca)
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        protected override string UtilesToString()
        {
            return base.UtilesToString();
        }
        public override string ToString()
        {
            return String.Format("{0} - Es de metal: {1} - PreciosCuidados: {2}",
                        this.UtilesToString(), this.deMetal, this.PreciosCuidados);
        }
    }
}
