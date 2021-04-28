using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Entidades.SP
{
    public class Banana : Fruta , ISerializar
    {
        protected string paisOrigen;

        public Banana() : this("", 0, "")
        {

        }
        public Banana(string color, double peso, string paisOrigen)
            : base(color, peso)
        {
            this.paisOrigen = paisOrigen;
        }

        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }
        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - Nombre: {1} - Pais de origen: {2} - Tiene Carozo: {3}",
                                    base.FrutaToString(), this.Nombre, this.paisOrigen, this.TieneCarozo);
        }

        public bool Xml(string path)
        {
            bool ret = true;
            try
            {

                using (StreamWriter wr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)))
                {
                    XmlSerializer se = new XmlSerializer(typeof(Banana));
                    se.Serialize(wr, this);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }
    }
}
