using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Entidades;

namespace _04_Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            Dato d = new Dato("Pepe", 20);

            try
            {
                //Creo un objeto que 'sabe' como escribir en XML
                using (XmlTextWriter writer = new XmlTextWriter("Datos.xml", System.Text.Encoding.UTF8))
                {
                    //Creo un objeto que 'sabe' como serializar a XML
                    //Le tengo que indicar que tipo de objeto se va a serializar
                    XmlSerializer ser = new XmlSerializer(typeof(Dato));

                    //Utilizo el método Serialize, pasándole el 'escritor' de XML
                    //y el objeto a serializar
                    ser.Serialize(writer, d);
                }

                //Creo un objeto que 'sabe' como leer de XML
                using (XmlTextReader reader = new XmlTextReader("Datos.xml"))
                {
                    //Creo un objeto que 'sabe' como deserializar de XML
                    //Le tengo que indicar que tipo de objeto se va a deserializar
                    XmlSerializer ser = new XmlSerializer(typeof(Dato));


                    //Utilizo el método Deserialize, pasándole el 'lector' de XML
                    //Debo 'castear' al tipo de dato específico, ya que 
                    //el método Deserialize retorna un Object
                    Dato aux = (Dato)ser.Deserialize(reader);

                    Console.WriteLine(aux.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Falló la serialización. Razones: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Saliendo del programa...");
                Console.ReadLine();
            }
        }
    }
}
