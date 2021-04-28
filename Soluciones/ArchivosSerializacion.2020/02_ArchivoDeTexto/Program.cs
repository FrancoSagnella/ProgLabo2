using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02_ArchivoDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding miCodificacion = Encoding.UTF8;

            try
            {
                //Al colocar el parámetro append en false, se sobrescribe.
                using (StreamWriter sw = new StreamWriter(@"C:\archivos\Test.txt", false, miCodificacion))
                {
                    sw.WriteLine("-----------------------------");
                    sw.WriteLine("ARCHIVO SOBRESCRITO....");
                    sw.WriteLine("-----------------------------");
                }

                //Al colocar el parámetro append en true, agrego datos.
                using (StreamWriter sw = new StreamWriter(@"C:\archivos\Test.txt", true, miCodificacion))
                {
                    sw.WriteLine("Línea agregada al archivo original...");
                }

                using (StreamReader sr = new StreamReader(@"C:\archivos\Test.txt", miCodificacion))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }

                using (StreamWriter sw = new StreamWriter(@"C:\archivos\Test.txt"))
                {
                    sw.WriteLine("Línea agregada al archivo original...");
                }

                using (StreamReader sr = new StreamReader(@"C:\archivos\Test.txt"))
                {
                    Console.WriteLine(sr.Read());
                    Console.WriteLine(sr.Read());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
