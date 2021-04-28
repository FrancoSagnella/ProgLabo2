using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Ejemplo
{
    public class Auto : IVendible
    {
        public ConsoleColor color;
        public string marca;

        public Auto(string marca, ConsoleColor color)
        {
            this.color = color;
            this.marca = marca;
        }

        public override string ToString()
        {
            return this.color.ToString() + " - " + this.marca;
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
            return this.Precio * this.Cantidad;
        }

        #endregion

    }
}
