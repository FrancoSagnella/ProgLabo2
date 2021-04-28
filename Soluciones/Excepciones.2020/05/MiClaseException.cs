using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05
{
    class MiClaseException : Exception
    {
        public MiClaseException()
            : base("Mensaje de error personalizado de MiClaseException")
        {
        }

        public MiClaseException(string mensaje)
            : base(mensaje)
        {
        }

        public MiClaseException(string mensaje, Exception innerException)
            : base(mensaje, innerException)
        {
        }

        public MiClaseException(string mensaje, Exception innerException, string origenError)
            :base(mensaje, innerException)
        {
            base.Source = origenError;
        }

        public override string ToString()
        {
            return "Mensaje de error: " + base.Message + "\nOrigen: " + base.Source;
        }

    }
}
