using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03_ArchivoDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Si no existe el archivo, lo copio de C:\Test.txt
                if ( ! File.Exists(@"C:\Users\Maxi\Desktop\miArchivo.txt"))
                {
                    File.Copy(@"C:\archivos\Test.txt", @"C:\Users\Maxi\Desktop\miArchivo.txt");
                }
                else // Si existe, lo borro.
                {
                    File.Delete(@"C:\Users\Maxi\Desktop\miArchivo.txt");
                }

                using (StreamReader sr = new StreamReader(@"C:\Users\Maxi\Desktop\miArchivo.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
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

            #region Mejora

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                using (StreamWriter sw = new StreamWriter(escritorio + @"\miArchivo.txt" , true))
                {
                    sw.WriteLine("Otra línea agregada al archivo...");
                }

                using (StreamReader sr = new StreamReader(escritorio + @"\miArchivo.txt"))
                {
                    Console.WriteLine(sr.ReadToEnd());
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
