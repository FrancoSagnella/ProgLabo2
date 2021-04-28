using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
        public enum ETipoTrazo
        {
            Fino,
            Medio,
            Grueso
        }

        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz():base("", 0)
        {

        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
            :base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }
        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }

        protected override string UtilesToString()
        {
            return String.Format("{0} - Color: {1} - Trazo: {2} - Precios Cuidados: {3}", base.UtilesToString(),
                                        this.color.ToString(), this.trazo.ToString(), this.PreciosCuidados);
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }

        public bool Xml()
        {
            bool ret = false;

            try
            {
                //PARA SERIALIZAR
                //INSTANCIO DENTRO DE UN USING UN TEXTWRITER, CON UN NEW STREAMWRITER QUE LE PASO EL PATH
                using(StreamWriter tw = new StreamWriter(this.Path))
                {
                    //INSTANCIO UN XMLSERIALIZER CON EL TIPO DE DATO QUE VA A SERIALIZAR
                    XmlSerializer sr = new XmlSerializer(typeof(Lapiz));
                    //USO METODO SERIALIZE, PASANDOLE EL TEXTWRITER Y EL OBJETO AS ERIALIZAR
                    sr.Serialize(tw, this);
                    ret = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            return ret;
            
        } 
        public string Path
        {
            get
            {
                //devolver carpetas especificas (Escritorio)
                //Tengo que usar Environment.GetPathFolder
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SagnellaFrancoLapiz.xml";
            }
        }
        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool ret = false;
            try
            {
                //PARA DESERIALIZAR
                //INSTANCIO UN TEXTREADER CON UN STREAMREADER, LE PASO EL PATH
                using (StreamReader tr = new StreamReader(this.Path))
                {
                    //INSTANCIO UN XMLSERIALIZER CON EL TIPO QUE VA A DESERIALIZAR
                    XmlSerializer sr = new XmlSerializer(typeof(Lapiz));
                    //USO EL METODO DESERIALIZE, PASANDOLE COMO PARAMETRO EL TEXTREADER
                    //PERO LO TENGO QUE CASTEAR AL TIPO, SE LO ASIGNO AL OBJETO LAPIZ QUE
                    //DEBERIA RECIBIR COMO PARAMETRO OUT
                    lapiz = (Lapiz)sr.Deserialize(tr);
                    ret = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return ret;
        }
    }
}
