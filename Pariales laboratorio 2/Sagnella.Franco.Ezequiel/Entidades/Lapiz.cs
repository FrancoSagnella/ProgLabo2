using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public class Lapiz : Utiles, IDeserializa, ISerializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public override bool PreciosCuidados
        {
            get { return true; }
        }

        public Lapiz() : this(0, 0, "", 0)
        {

        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        protected override string UtilesToString()
        {
            return base.UtilesToString();
        }
        public override string ToString()
        {
            return String.Format("{0} - Color: {1} - Trazo: {2} - Precios Cuidados: {3}",
                        this.UtilesToString(), this.color, this.trazo, this.PreciosCuidados);
        }

        public bool Xml()
        {
            bool ret = true;
            try
            {
                using (StreamWriter sr = new StreamWriter(this.Path))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Lapiz));
                    serializador.Serialize(sr, this);
                }
            }
            catch (Exception e)
            {
                ret = false;
            }
            return ret;
        }
        public string Path
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Sagnella.Franco.Lapiz.xml";
            }
        }
        bool IDeserializa.Xml(out Lapiz l)
        {
            l = null;
            bool ret = true;
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(Lapiz));

                    l = (Lapiz)ser.Deserialize(sr);
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
