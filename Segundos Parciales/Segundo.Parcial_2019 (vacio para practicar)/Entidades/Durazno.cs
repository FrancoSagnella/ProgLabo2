using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;

namespace Entidades.SP
{
    public class Durazno : Fruta , ISerializar
    {
        protected int cantPelusa;

        public Durazno() : this("", 0, 0)
        {

        }
        public Durazno(string color, double peso, int cantPelusa)
            : base(color, peso)
        {
            this.cantPelusa = cantPelusa;
        }

        public string Nombre
        {
            get
            {
                return "Durazno";
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
            return String.Format("{0} - Nombre: {1} - Cantidad de Pelusa: {2} - Tiene Carozo: {3}",
                                base.FrutaToString(), this.Nombre, this.cantPelusa, this.TieneCarozo);
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
