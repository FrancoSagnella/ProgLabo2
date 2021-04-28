using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventos.Entidades
{
    /// <summary>
    /// Clase para guardar información sobre
    /// los eventos lanzados por la clase EmpleadoMejorado;
    /// esta clase en concreto, guardará el valor del sueldo
    /// erróneo que se ha intentado asignar a un empleado.
    /// </summary>
    public class EmpleadoEventArgs : EventArgs
    {
        public Double SueldoIntentadoAsignar { get; set; }
    }
}
