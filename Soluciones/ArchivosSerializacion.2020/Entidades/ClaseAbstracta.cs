using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(ClaseHija1))]
    [XmlInclude(typeof(ClaseHija2))]
    public abstract class ClaseAbstracta
    {
        protected int datoEntero;
        protected string datoTexto;

        public int DatoEntero 
        { 
            get
            {
                return this.datoEntero;
            }
            set
            {
                this.datoEntero = value;
            }
        }

        public string DatoTexto
        {
            get
            {
                return this.datoTexto;
            }
            set
            {
                this.datoTexto = value;
            }
        }

        public ClaseAbstracta()
        {
            this.datoEntero = 1;
            this.datoTexto = "sin texto";
        }

        public ClaseAbstracta(int datoEntero, string datoTexto)
        {
            this.datoEntero = datoEntero;
            this.datoTexto = datoTexto;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Datos de la Clase Padre");
            sb.AppendLine(this.datoEntero.ToString());
            sb.AppendLine(this.datoTexto);
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
