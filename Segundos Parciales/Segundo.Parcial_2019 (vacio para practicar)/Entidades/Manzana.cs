using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.IO;

namespace Entidades.SP
{
    public class Manzana : Fruta , ISerializar, IDeserializar
    {
        protected string provinciaOrigen;

        public string ProvinciaOrigen
        {
            get
            {
                return this.provinciaOrigen;
            }
            set
            {
                this.provinciaOrigen = value;
            }
        }
        public Manzana():base("", 0)
        {

        }
        public Manzana(string color, double peso, string provinciaOrigen)
            :base(color, peso)
        {
            this.provinciaOrigen = provinciaOrigen;
        }

        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }
        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} - Nombre: {1} - Provincia de origen: {2} - Tiene Carozo: {3}",
                                    base.FrutaToString(), this.Nombre, this.provinciaOrigen, this.TieneCarozo);
        }

        public bool Xml(string path)
        {
            bool ret = true;
            try
            {

                using (StreamWriter wr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+path))
                {
                    XmlSerializer se = new XmlSerializer(typeof(Manzana));
                    se.Serialize(wr, this);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }
        bool IDeserializar.Xml(string path, out Fruta f)
        {
            bool ret = true;
            try
            {
                using(StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +"\\"+ path))
                {
                    XmlSerializer se = new XmlSerializer(typeof(Manzana));
                    f = (Manzana)se.Deserialize(sr);
                }
            }
            catch(Exception e)
            {
                ret = false;
                f = null;
            }
            return ret;
        }
    }
}
