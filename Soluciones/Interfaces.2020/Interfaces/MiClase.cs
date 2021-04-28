using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MiClase : IMiInterface
    {
        public string atributo;

        public MiClase(string atributo)
        {
            this.atributo = atributo;
        }

        public override string ToString()
        {
            return this.atributo;
        }

        #region Implementación de la interface

        public int PropiedadLE 
        {
            get { return this.atributo.Length; } 
            set { this.atributo = value.ToString(); } 
        }

        public int PropiedadSL
        {
            get { return 66; }
        }

        public int PropiedadSE
        {
            set { this.atributo = value.ToString(); }
        }

        public double MetodoConParametros(int p1, int p2)
        {
            return p1 + p2;
        }

        public void MetodoSinRetornoNiParametros()
        {
            Console.WriteLine("Método de interface");
        }

        #endregion

    }
}
