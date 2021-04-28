using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class MiClaseDerivada : MiClase, IMiOtraInterface
    {
        public string atributoDerivado;

        public MiClaseDerivada(string atributo, string atributoDerivado) 
            : base(atributo)
        {
            this.atributoDerivado = atributoDerivado;
        }

        public override string ToString()
        {
            return base.ToString() + " - " + this.atributoDerivado;
        }

        public void OtroMetodo()
        {
            Console.WriteLine("...implementar...");
        }

    }
}
