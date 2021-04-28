using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBD;

namespace ConsolaTestBD
{
    class Program
    {
        static void Main(string[] args)
        {
            //PASO LA CADENA DE CONEXION
            string cadena = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";

            AccesoDatos ad = new AccesoDatos(cadena);

            if (ad.ProbarConexion())
            {
                Console.WriteLine("se conectó");
            }
            else
            {
                Console.WriteLine("no se conectó");
            }

            //SACA INTERNAMENTE LA CADENA DE CONEXION
            AccesoDatos ado = new AccesoDatos();

            if (ado.ProbarConexion())
            {
                Console.WriteLine("se conectó");
            }
            else
            {
                Console.WriteLine("no se conectó");
            }

            List<Dato> lista = ado.ObtenerListaDato();

            foreach (Dato item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            Dato obj = new Dato();
            obj.cadena = "nuevo";
            obj.entero = 100;
            obj.flotante = 33f;

            bool agrego = ado.AgregarDato(obj);

            if (agrego)
            {
                Console.WriteLine("se agregó");
            }
            else
            {
                Console.WriteLine("no se agregó");
            }

            lista = ado.ObtenerListaDato();

            foreach (Dato item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            obj.id = 5;
            obj.cadena = "modificado";
            obj.entero = 666;
            obj.flotante = 0.99f;

            bool modifico = ado.ModificarDato(obj);

            if (modifico)
            {
                Console.WriteLine("se modificó");
            }
            else
            {
                Console.WriteLine("no se modificó");
            }

            lista = ado.ObtenerListaDato();

            foreach (Dato item in lista)
            {
                Console.WriteLine(item.ToString());
            }


            bool elimino = ado.EliminarDato(6);

            if (elimino)
            {
                Console.WriteLine("se eliminó");
            }
            else
            {
                Console.WriteLine("no se eliminó");
            }

            lista = ado.ObtenerListaDato();

            foreach (Dato item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadLine();
        }
    }
}
