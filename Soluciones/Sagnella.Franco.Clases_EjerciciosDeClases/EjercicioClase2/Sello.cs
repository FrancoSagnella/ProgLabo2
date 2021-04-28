using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase2
{
    class Sello
    {
        public static string mensaje;
        public static ConsoleColor color;

        public static string Imprimir()
        {
            return Sello.ArmarFormatoMensaje();
        }
        public static void Borrar()
        {
            Sello.mensaje = "";
        }
        public static void ImprimirColor()
        {
            Console.ForegroundColor = Sello.color;
            Console.WriteLine(Sello.Imprimir());
            Sello.color = ConsoleColor.White;
            Console.ForegroundColor = Sello.color;
        }
        private static string ArmarFormatoMensaje()
        {
            string recuadro = "";
            string mensajeFormateado = "";
            int cantidad = Sello.mensaje.Length;

            if(cantidad != 0)
            {
                for (int i = 0; i < cantidad+2; i++)
                {
                    recuadro += "*";
                }
                mensajeFormateado = recuadro + "\n*" + Sello.mensaje + "*\n" + recuadro;
            }

            return mensajeFormateado;
        }
     }
}
