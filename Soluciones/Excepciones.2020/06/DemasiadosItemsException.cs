using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06
{
    class DemasiadosItemsException: Exception
    {
        public DemasiadosItemsException()
            : base("Demasiados items")
        {
        }
    }
}
