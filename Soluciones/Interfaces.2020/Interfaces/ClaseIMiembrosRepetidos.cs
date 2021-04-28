using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class ClaseIMiembrosRepetidos : IMiembrosRepetidos, IMiembrosRepetidos2
    {
        
        public void Metodo()
        {
            Console.WriteLine("Método de IMiembrosRepetidos");
        }
        
        void IMiembrosRepetidos2.Metodo()
        {
            Console.WriteLine("Método de IMiembrosRepetidos2");
        }
        
    }
}
