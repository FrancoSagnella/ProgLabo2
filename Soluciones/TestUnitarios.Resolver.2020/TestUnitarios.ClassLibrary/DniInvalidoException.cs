using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitarios.ClassLibrary
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase;

        static DniInvalidoException()
        {
            DniInvalidoException.mensajeBase = "El DNI ingresado no es un número válido. ";
        }

        public DniInvalidoException()
            : base (DniInvalidoException.mensajeBase)
        {

        }
        public DniInvalidoException(string message)
            : this(message, null)
        {

        }
        public DniInvalidoException(Exception e)
            : base(DniInvalidoException.mensajeBase, e)
        {

        }
        public DniInvalidoException(string message, Exception e)
            : base(DniInvalidoException.mensajeBase + message, e)
        {

        }
    }
}
