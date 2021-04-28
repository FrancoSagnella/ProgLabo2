using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase_4_Ejercicios
{
    class Cosa
    {
        private int entero;
        private string cadena;
        private DateTime fecha;

        public Cosa()
        {
            this.EstablecerValor(1);
            this.EstablecerValor("Hola");
            this.EstablecerValor(DateTime.Now);   
        }

        //Se va a ejecutar siempre el constructor que pongo despues del :
        public Cosa(int a, string b):this(b)//Esto lo puedo hacer para usar un constructor dentro de otro
        {
            this.EstablecerValor(a);
            //el :this(b), es el constructor que recibe una cadena
            //Este constructor esta usando a ese otro, aca solo se setea el entero
            //le pasa el string al otro, que setea el string

            //this.EstablecerValor(b);
            //this.EstablecerValor(DateTime.Now);
        }
        public Cosa(string a):this()
        {
            //this.EstablecerValor(1);

            //Este constructor usa al por default
            //Esta seteando el string
            //este utiliza el por default para setear la hora

            this.EstablecerValor(a);
            //this.EstablecerValor(DateTime.Now);
        }


        public void Mostrar()
        {
            Console.WriteLine("{0}\n{1}\n{2}",this.entero, this.cadena, this.fecha);
        }


        public void EstablecerValor(int a)
        {
            this.entero = a;
        }
        public void EstablecerValor(string a)
        {
            this.cadena = a;
        }
        public void EstablecerValor(DateTime a)
        {
            this.fecha = a;
        }
    }
}
