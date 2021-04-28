using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{

    public class ClaseHija2 : ClaseAbstracta
    {
        public bool datoBooleano;

        public ClaseHija2()
        { 
        }

        public ClaseHija2(int datoEntero, string datoTexto, bool datoBoolean)
            : base(datoEntero, datoTexto)
        {
            this.datoBooleano = datoBoolean;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("######################################");
            sb.AppendLine(base.ToString());

            sb.AppendLine("Datos de la Clase Hija2");
            sb.AppendLine(this.datoBooleano.ToString());
            sb.AppendLine("######################################");
            sb.AppendLine();

            return sb.ToString();
        }

    }
}
