using Clase_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crearobjetos
{
    class Program
    {
        static void Main(string[] args)
        {
            MiClase.MostrarCantidadObjetos();

            MiClase obj = new MiClase();//El new crea un lugar en memoria, y el constructor inicializa los atributos
            MiClase obj2 = new MiClase();
            //Puedo pasar los objetos como parametro de referencia en los metodos, para modificar sus atributos no estaticos

            Console.WriteLine(obj.atriburo);

            MiClase.MostrarCantidadObjetos();
            Console.ReadKey();

        }
    }
}
