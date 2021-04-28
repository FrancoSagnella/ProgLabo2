using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public abstract class Fruta
    {
        protected string color;
        protected double peso;
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public double Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                this.peso = value;
            }
        }
        public abstract bool TieneCarozo { get; }

        public Fruta(string color, double peso)
        {
            this.color = color;
            this.peso = peso;
        }
        protected virtual string FrutaToString()
        {
            return String.Format("Color: {0} - Precio: {1}", this.color, this.peso);
        }

    }
}
