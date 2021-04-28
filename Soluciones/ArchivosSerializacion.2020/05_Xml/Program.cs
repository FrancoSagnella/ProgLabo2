using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Entidades;

namespace _05_Xml
{
    class Program
    {
        static void Main(string[] args)
        {

            Lista<Dato> listaDato = new Lista<Dato>();
            Lista<Dato> listaDatoXML;

            Dato d1 = new Dato("juan", 22);
            Dato d2 = new Dato("pedro", 33);
            Dato d3 = new Dato("mara", 44);
            Dato d4 = new Dato("carmen", 55);

            listaDato.Items.Add(d1);
            listaDato.Items.Add(d2);
            listaDato.Items.Add(d3);
            listaDato.Items.Add(d4);

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter("C:\\archivos\\DatosLista.xml", Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(Lista<Dato>)));
                    ser.Serialize(writer, listaDato);
                }

                using (XmlTextReader reader = new XmlTextReader(@"C:\archivos\DatosLista.xml"))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(Lista<Dato>)));

                    listaDatoXML = (Lista<Dato>)ser.Deserialize(reader);
                }

               foreach (Dato miDato in listaDatoXML.Items)
                {
                    Console.WriteLine(miDato.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Error al Serializar/Deserializar los Datos");
            }

            finally
            {
                Console.WriteLine("Saliendo del programa...");
                Console.ReadLine();
            }
        }
    }
}
