using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MiOtraClase : IGenerica<ClaseConstructorDefecto>
    {
        public void Metodo(ClaseConstructorDefecto param)
        {
            Console.WriteLine(param.ToString());
        }

        public ClaseConstructorDefecto MetodoRetorno(ClaseConstructorDefecto param)
        {
            return param;
        }
    }
}
