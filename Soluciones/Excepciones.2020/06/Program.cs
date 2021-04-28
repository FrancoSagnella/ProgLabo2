using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Program.GenerarExcepcion(5, true);

                Program.GenerarExcepcion(5, false);
            }

            catch (DemasiadosItemsException e)
            {
                Console.WriteLine("Mensaje: {0}", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Mensaje: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Finally del Main");
                Console.ReadLine();
            }
        }


        private static void GenerarExcepcion(int CantIteraciones, bool lanzoExc)
        {
            int i = 3;
            int[] MiArray = new int[i];

            try
            {
                if (lanzoExc)
                {
                    if (CantIteraciones > MiArray.Length)
                    {
                        throw new DemasiadosItemsException();
                    }
                    else
                    {
                        for (int j = 0; j < CantIteraciones; j++)
                        {
                            MiArray[j] = j + 1;
                        }
                    }
                }

            }
            finally
            {
                Console.WriteLine("No importa lo que suceda, por el finally siempre pasa.");
                Console.WriteLine("Finally de Program.GenerarExcepcion");
            }

            Console.ReadLine();
        }
    }
}
