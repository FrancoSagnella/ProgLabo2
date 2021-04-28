using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace _07_Binario
{
    class Program
    {
        static void Main(string[] args)
        {
            DatoBinario db = new DatoBinario("Juan", 15, 22222222, "Juancho");

            //Creo un BinaryFormatter para serializar a Binario
            BinaryFormatter ser = new BinaryFormatter();

            FileStream fs;

            try
            {
                using (fs = new FileStream("C:\\archivos\\DatoBinario.dat", FileMode.Create))
                {
                    ser.Serialize(fs, db);
                }
                   
            }

            catch (SerializationException e)
            {
                Console.WriteLine("Falló la serialización. Razones: " + e.Message);

            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha provocado un error: " + e.Message);
            }


            try
            {
                DatoBinario aux;
                
                using (fs = new FileStream("C:\\archivos\\DatoBinario.dat", FileMode.Open))
                {
                    aux = (DatoBinario)ser.Deserialize(fs);
                }

                Console.WriteLine(aux.ToString());
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Falló la deserialización. Razones: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha provocado un error: " + e.Message);
            }

            try
            {
                IFormatter formateador = new BinaryFormatter();

                using (Stream archivo = new FileStream("C:\\archivos\\DatoBinario2.dat", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formateador.Serialize(archivo, db);
                }

                using (Stream archivo = new FileStream("C:\\archivos\\DatoBinario2.dat", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    DatoBinario dato = (DatoBinario)formateador.Deserialize(archivo);

                    Console.WriteLine(dato.ToString());
                }              

            }
            catch (Exception e)
            {
                Console.WriteLine("Se ha provocado un error: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Pulse una tecla para finalizar...");
                Console.ReadLine();
            }
        }
    }
}
