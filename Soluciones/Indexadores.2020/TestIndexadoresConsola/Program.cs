using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace TestIndexadoresConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Arrays

            LibroArray miLibrito = new LibroArray("C# al descubierto", "Joe Mayo");

            miLibrito[0] = "Fundamentos Básicos de C#";

            miLibrito[1] = "Título que se va a modificar";
            miLibrito[1] = "Cómo comenzar con C#";

            miLibrito[2] = "Cómo escribir expresiones con C#";

            miLibrito[-1] = "Genero un índice erroneo";

            Console.ReadLine();

            Console.WriteLine("Título: {0}", miLibrito.Titulo);
            Console.WriteLine("Autor: {0}", miLibrito.Autor);

            for (int i = 0; i < miLibrito.CantidadDeCapitulos; i++)
            {
                Console.WriteLine("Capítulo {0}: {1}", miLibrito[i].Numero, miLibrito[i].Titulo);
            }

            Console.ReadLine();

            #endregion

            #region Colecciones

            Libro miLibro = new Libro("C# al descubierto", "Joe Mayo");

            miLibro[0] = "Fundamentos Básicos de C#";
            miLibro[1] = "Cómo comenzar con C#"; ;
            miLibro[2] = "Cómo escribir expresiones con C#";

            miLibro[-1] = "Genero un índice erroneo";

            Console.ReadLine();

            Console.WriteLine("Título: {0}", miLibro.Titulo);
            Console.WriteLine("Autor: {0}", miLibro.Autor);

            for (int i = 0; i < miLibro.CantidadDeCapitulos; i++)
            {
                Console.WriteLine("Capítulo {0}: {1}", miLibro[i].Numero, miLibro[i].Titulo);
            }


            Console.ReadLine();


            #region Asociativo

            Asociativa asoc = new Asociativa();

            asoc["uno"] = "capítulo uno";

            //INDICE REPETIDO
            asoc["uno"] = "capítulo uno";

            asoc["dos"] = "capítulo dos";
            asoc["tres"] = "capítulo tres";

            Console.WriteLine(asoc.VerCapitulos());

            Console.WriteLine();

            Console.WriteLine("Capítulo {0}: {1}", asoc["uno"].Numero, asoc["uno"].Titulo);
            Console.WriteLine("Capítulo {0}: {1}", asoc["tres"].Numero, asoc["tres"].Titulo);

            //NO EXISTE EL INDICE --> RETORNA NULL
            //Console.WriteLine("Capítulo {0}: {1}", asoc["??"].Numero, asoc["??"].Titulo);

            Console.ReadLine();

            #endregion


            #endregion

        }
    }
}
