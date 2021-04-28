using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4_sobrecargas
{
    class Program
    {
        public int entero;
        private float flotante;

        /// Puedo sobrecargar constructores
        /// creo cosntructores que reciben diferentes parametros

        public Program()
        {
            this.entero = 1;
            this.flotante = 1.1f;//(float)1.1;
        }
        public Program(int entero)
        {
            this.entero = entero;
        }
        public Program(float f)
        {
            this.flotante = f;
        }
        public Program(int a, float b)
        {
            this.entero = a;
            this.flotante = b;
        }
        public Program(float a, int b)
        {
            this.entero = b;
            this.flotante = a;
        }


        //Son todos metodos que se llaman igual pero tienen diferentes los parametros
        //eso es una sobrecarga
        //Metodos que hacen lo mismo pero con diferentes parametros
        private static void MetodoSobrecargado()
        {
            Console.WriteLine("Sin parametros");
        }

        private static void MetodoSobrecargado(int num)
        {
            Console.WriteLine(num);
        }

        private static void MetodoSobrecargado(string a)
        {
            Console.WriteLine(a);
        }

        private void MetodoSobrecargado(string b, out int a)
        {
            if (int.TryParse(b, out a))
            {
                Console.WriteLine("se covirtio {0}", a);
            }
            else
            {
                Console.WriteLine("no se covirtio {0}", a);
            }
        }

        //va a retornar strings con los valores de los atributos
        //Uqe sea static o no no influye para sobrecargar
        //Una sobrecarga, hacen lo mismo pero uno es static y el otro no
        private string VerValores()
        {
            return this.entero + " -- " + this.flotante;
        }
        private static string VerValores(Program p)
        {
            //puedo volver a concatenar
            ////return p.entero + " - " + p.flotante;
            //o puedo llamar al metodo de instancia para reutilizar codigo
            return p.VerValores();
        }
        static void Main(string[] args)
        {
            Program.MetodoSobrecargado();
            Program.MetodoSobrecargado(2);
            Program.MetodoSobrecargado("hola");

            Program p = new Program();

            int numero;
            p.MetodoSobrecargado("88", out numero);

            Program p2 = new Program(4);
            Program p3 = new Program(2.4f);
            Program p4 = new Program(2, 3.2f);
            Program p5 = new Program(5.4f, 1);

            //Mostrar no estatico
            //lo invoco desde el objeto
            Console.WriteLine(p.VerValores());
            Console.WriteLine(p2.VerValores());
            Console.WriteLine(p3.VerValores());
            Console.WriteLine(p4.VerValores());
            Console.WriteLine(p5.VerValores());

            //mostrar estatico
            //le paso el objeto
            Console.WriteLine(Program.VerValores(p));
            Console.WriteLine(Program.VerValores(p2));
            Console.WriteLine(Program.VerValores(p3));
            Console.WriteLine(Program.VerValores(p4));
            Console.WriteLine(Program.VerValores(p5));

            Console.ReadKey();
        }
    }
}
