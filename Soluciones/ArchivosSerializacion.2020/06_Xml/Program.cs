using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Entidades;

namespace _06_Xml
{
    class Program
    {
        static void Main(string[] args)
        { 
            List<ClaseAbstracta> lista = new List<ClaseAbstracta>();

            lista.Add(new ClaseHija1(1, "Cadena1", 1.1));
            lista.Add(new ClaseHija2(2, "Cadena2", true));
            lista.Add(new ClaseHija1(3, "Cadena3", 2.2));
            lista.Add(new ClaseHija2(4, "Cadena4", false));

            try
            {
                using (XmlTextWriter writer = new XmlTextWriter("DatosListaHerencia.xml", Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<ClaseAbstracta>)));

                    ser.Serialize(writer, lista);
                }

                using (XmlTextReader reader = new XmlTextReader("DatosListaHerencia.xml"))
                {
                    XmlSerializer ser = new XmlSerializer((typeof(List<ClaseAbstracta>)));

                    lista = (List<ClaseAbstracta>) ser.Deserialize(reader);
                }

                foreach (ClaseAbstracta item in lista)
                {
                    Console.WriteLine(item.ToString());
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Error al Serializar los Datos");
            }

            Console.ReadLine();
        }
    }
}
