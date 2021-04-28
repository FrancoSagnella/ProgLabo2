using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eventos.Entidades;

namespace Eventos.Consola2
{
    class Program
    {
        static void Main(string[] args)
        {
            //CREO OBJETOS DE TIPO 'EMPLEADO'
            Empleado e1 = new Empleado();
            Empleado e2 = new Empleado();
            Empleado e3 = new Empleado();


            e1.LimiteSueldo +=new LimiteSueldoDelegado(Program.SobreAsignacionSueldo);

            e2.LimiteSueldo += new LimiteSueldoDelegado(Program.SalarioIncorrecto);

            e3.LimiteSueldo += new LimiteSueldoDelegado(Program.SobreAsignacionSueldo);
            e3.LimiteSueldo += new LimiteSueldoDelegado(Program.SalarioIncorrecto);

            Console.Clear();

            //ASIGNO VALORES A LAS PROPIEDADES
            e1.Nombre = "ANTONIO";
            e2.Nombre = "JUAN";
            e3.Nombre = "ROSA";

            //ESTAS ASIGNACIONES PROVOCARAN EL EVENTO, Y SE EJECUTARAN
            //LOS MANEJADORES ASOCIADOS

            e1.Sueldo = 25000;

            e2.Sueldo = 30000;

            e3.Sueldo = 28000;

            Console.ReadLine();
        }

    #region Manejadores

        //MANEJADORES DE EVENTO QUE CONECTO EN TIEMPO DE EJECUCION
        public static void SobreAsignacionSueldo(Double importe, Empleado e)
        {
            Console.WriteLine("Se intentó asignar al empleado {1} el sueldo de $" +
                        " {0:#,###.00}\n¡ESTO ES INCORRECTO!", importe, e.Nombre);

        }

        public static void SalarioIncorrecto(Double importe, Empleado e)
        {

            Console.WriteLine("INFORME DE INCIDENCIAS");
            Console.WriteLine("======================");
            Console.WriteLine("Error al intentar asignar un salario de $ " +
                        "{0:#,###.00} al empleado {1}.", importe, e.Nombre);

        }

    #endregion

    }
}
