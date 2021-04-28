using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class ClaseGenerica<T> : IGenerica<T>
        where T : new()
    {
        public void Metodo(T param)
        {
            Console.WriteLine(param.ToString());
        }

        public T MetodoRetorno(T param)
        {
            throw new NotImplementedException();
        }
    }
}
