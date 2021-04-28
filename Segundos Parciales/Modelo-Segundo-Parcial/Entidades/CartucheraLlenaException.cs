using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException():this("Se excedio la capacidad de la cartuchera")
        {

        }
        public CartucheraLlenaException(string message)
            :base(message)
        {

        }
    }
}
