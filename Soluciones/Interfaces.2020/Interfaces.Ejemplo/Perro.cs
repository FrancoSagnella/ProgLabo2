using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Ejemplo
{
    public class Perro : Mascota, IVendible
    {
        public string nombre;

        public Perro(string nombre)
        {
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return this.nombre;
        }

        #region IVendible

        public double Cantidad
        {
            get;
            set;
        }

        public double Precio
        {
            get;
            set;
        }

        public double Vender()
        {
            return 0;//this.Precio * this.Cantidad;
        }

        #endregion

    }
}
