using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eventos.Entidades;

namespace Eventos.Consola3
{
    class Program
    {
        static void Main(string[] args)
        {
            //DECLARO E INSTANCIO UN OBJETO 'EMPLEADOMEJORADO'
            EmpleadoMejorado miEmpleadoMejorado = new EmpleadoMejorado();

            //AGREGO UN MANEJADOR DE EVENTO
            miEmpleadoMejorado.LimiteSueldo +=new LimiteSueldoDelegadoMejorado(Program.SobreAsignacionSueldo);

           //ASIGNO VALORES A LAS PROPIEDADES
            miEmpleadoMejorado.Nombre = "ANA";

            //ESTO PROVOCA EL EVENTO
            miEmpleadoMejorado.Sueldo = 50000;

            Console.ReadLine();
        }

        /// <summary>
        /// Manejador del evento LimiteSueldo.
        /// </summary>
        /// <param name="sender">Se obtendrá el nombre del empleado</param>
        /// <param name="e">Se obtendrá el importe incorrecto</param>
        public static void SobreAsignacionSueldo(EmpleadoMejorado sender, EmpleadoEventArgs e)
        {
            Console.WriteLine("Se intentó asignar al empleado {0} el sueldo de $" +
                        " {1:#,###.00}\n¡ESTO ES INCORRECTO!", sender.Nombre, e.SueldoIntentadoAsignar);

        }

    }
}
