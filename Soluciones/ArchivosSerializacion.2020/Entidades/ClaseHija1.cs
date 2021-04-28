using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class ClaseHija1 : ClaseAbstracta
    {
        public double datoReal;

        public ClaseHija1()
        { 
        }

        public ClaseHija1(int datoEntero, string datoTexto, double datoDoble)
            : base(datoEntero, datoTexto)
        {
            this.datoReal = datoDoble;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("######################################");
            sb.AppendLine(base.ToString());

            sb.AppendLine("Datos de la Clase Hija1");
            sb.AppendLine(this.datoReal.ToString());
            sb.AppendLine("######################################");
            sb.AppendLine();

            return sb.ToString();
        }

    }
}
