using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class OtraCosa
    {
        public static string algo;
        public int entero;
        public string cadena;

        public OtraCosa(int a)
        {
            this.entero = a;
        }
        public OtraCosa(string a)
        {
            this.cadena = a;
        }
        //Tengo una sobrecarga iogual a la de la otra clase, esto me tira error
        /*public static bool operator ==(Cosa c1, OtraCosa c2)
        {
            if (c1.entero == c2.entero && c1.cadena == c2.cadena)//tendrai que acceder a los atributos, para comparar atributos del mismo tipo, que estan adentro de tipos de clases diferentes
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Cosa c1, OtraCosa c2)
        {
            return !(c1 == c2);// lo mismo de arriba pero sin construir ninguna variable
        }*/


        //Podria hacerlo invirtiendo los parametros
        public static bool operator ==(OtraCosa c1, Cosa c2)
        {
            if (c1.entero == c2.entero && c1.cadena == c2.cadena)//tendrai que acceder a los atributos, para comparar atributos del mismo tipo, que estan adentro de tipos de clases diferentes
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(OtraCosa c1, Cosa c2)
        {
            return !(c1 == c2);// lo mismo de arriba pero sin construir ninguna variable
        }


        //CONVERSORES
        public static implicit operator OtraCosa(int n)//Puede recibir solo un parametro
        {
            return new OtraCosa(n);//Creo un nuevo objeto metiendole el numero que me vino
        }
        public static explicit operator OtraCosa(string s)//Puede recibir solo un parametro
        {
            return new OtraCosa(s);//Creo un nuevo objeto metiendole el numero que me vino
        }
    }
}
