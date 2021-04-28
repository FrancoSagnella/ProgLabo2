using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01_ArchivoDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Escritura de archivo

            try
            {
                // Abro un archivo
                StreamWriter sw = new StreamWriter("C:\\archivos\\Test.txt");
                // Escribo
                sw.WriteLine("Hola mundo!!!");
                // Cierro el archivo
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Escritura de archivo

            try
            {
                //El bloque using asegura que el objeto invocará al método Dispose()
                using (StreamWriter sw = new StreamWriter("C:\\archivos\\Test.txt"))
                {
                    sw.Write("Este es el ");
                    sw.WriteLine("encabezado para el archivo.");
                    sw.WriteLine("-----------------------------");

                    // Objetos arbitrarios tambien pueden ser escritos en el archivo.
                    sw.Write("LA FECHA ES: ");
                    sw.WriteLine(DateTime.Now);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            #region Lectura de archivo

            try
            {
                // Crea una instancia de StreamReader para leer desde el archivo.
                using (StreamReader sr = new StreamReader("C:\\archivos\\Test.txt"))
                {
                    String linea;

                    // Lee y muestra líneas desde el comienzo del archivo 
                    // hasta el fin del mismo.
                    while ((linea = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(linea);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion
        }
    }
}
