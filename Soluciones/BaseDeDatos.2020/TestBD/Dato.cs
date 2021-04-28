using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBD
{
    public class Dato
    {
        public int id;
        public string cadena;
        public int entero;
        public float flotante;

        public override string ToString()
        {
            return this.id.ToString() + " - " + this.cadena + " - " + this.entero.ToString() + " - " + this.flotante.ToString();
        }
    }
}
