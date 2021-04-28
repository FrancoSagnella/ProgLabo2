using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cosa//La clase publica para poder usarla en otro proyecto
    {
        public int entero;
        public string cadena;
        private DateTime fecha;

        public Cosa()
        {
            this.EstablecerValor(1);
            this.EstablecerValor("Hola");
            this.EstablecerValor(DateTime.Now);
        }

        //Se va a ejecutar siempre el constructor que pongo despues del :
        public Cosa(int a, string b) : this(b)//Esto lo puedo hacer para usar un constructor dentro de otro
        {
            this.EstablecerValor(a);
            //el :this(b), es el constructor que recibe una cadena
            //Este constructor esta usando a ese otro, aca solo se setea el entero
            //le pasa el string al otro, que setea el string

            //this.EstablecerValor(b);
            //this.EstablecerValor(DateTime.Now);
        }
        public Cosa(string a) : this()
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
            Console.WriteLine("{0}\n{1}\n{2}", this.entero, this.cadena, this.fecha);
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

        public static bool operator ==(Cosa c1, OtraCosa c2)
        {
            if (c1.entero == c2.entero && c1.cadena == c2.cadena)//tendrai que acceder a los atributos, para comparar atributos del mismo tipo, que estan adentro de tipos de clases diferentes
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Cosa c1, OtraCosa c2)
        {
            /*if (c1.entero != c2.entero)//Lo puedo hacer a la inversa, pero me la re complico
            {
                return true;
            }
            return false;*/

            /*if (c1 == c2)//Reutilizo el codigo del ==, y le invierto el resultado
            {
                return false;
            }
            return true;*/

            /*bool ret = !(c1 == c2);//COMO eso ya me devuelve un true o un false, yo lo niego y lo devielvo directamente
            return ret;*/

            return !(c1 == c2);// lo mismo de arriba pero sin construir ninguna variable
        }


        //teniendo sobrecargado algun operador, va afuncionar que haga +=, *=. -=, etc
        public static Cosa operator +(Cosa c, Cosa c1)//Puedo sumar dos cosas, y construir una nueva cosa para devolverla
        {
            int rta = c.entero + c1.entero;
            return new Cosa(rta, "");
        }
        public static Cosa operator ++(Cosa c)//me va a dejar hacer cosa++, y funciona sumadnole ++ al entero atributo
        {
            c.entero++;
            return c;
        }

    }
}
