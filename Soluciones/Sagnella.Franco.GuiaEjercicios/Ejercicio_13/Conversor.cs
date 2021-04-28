using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_13
{
    class Conversor
    {
        public static string DecimalBinario(double valor)
        {
            int numero = (int)valor;
            float flotante = (float)(valor - numero);
            string binario = "";
            string binarioFlotante = ".";

            while(numero > 0)
            {
                if(numero % 2 == 0)
                {
                    binario = "0" + binario;//no puedo hacer +=, tiene que ser asi, para que el 0 o el 1 se pongan a la izquierda
                }
                else
                {
                    binario = "1" + binario;
                }
                numero = (int)(numero/2);
            }

            while(flotante > 0)
            {
                flotante *= 2;
                numero = (int)flotante;
                if(flotante - (flotante - numero) == 1)
                {
                    binarioFlotante += "1";
                }
                else
                {
                    binarioFlotante += "0";
                }
                flotante -= numero; 
            }
            return binario+binarioFlotante;
        }
        public static double BinarioDecimal(string cadena)
        {
            int largoCadena = cadena.Length;
            string cadenaEntero = "";
            int largoCadenaEntero;
            string cadenaFlotante = "";
            int largoCadenaFlotante;
            int numAux;
            double numero = 0;
            double numeroFlotante = 0;


            for (int i = 0; i < largoCadena; i++)
            {
                if(cadena[i] == ',')
                {
                    for(int j = i+1; j < largoCadena; j++)
                    {
                        cadenaFlotante += cadena[j];
                    }
                    break;
                }
                cadenaEntero += cadena[i];
            }

            largoCadenaEntero = cadenaEntero.Length;
            for(int i = 1; i <= largoCadenaEntero; i++)
            {
                numAux = cadenaEntero[i-1] - '0';//'0' es 48, al restarlo con cualquie numero, por ejemplo '9' es 57, entonces 57 - 48 = 9
                                           //i-1 porque quiero el indice 0
                numero += (numAux * Math.Pow(2, largoCadenaEntero-i));//Elevo el caracter 0 o 1 por la posicion en la que esta, 
                                                          //pongo - i porque quiero que sea 4, despues 3, 2, 1, 0
            }

            if(cadenaFlotante != "")
            {
                largoCadenaFlotante = cadenaFlotante.Length;
                for(int i = 1; i <= largoCadenaFlotante; i++)
                {
                    numAux = cadenaFlotante[i - 1] - '0';
                    numeroFlotante += (numAux * Math.Pow(2, -i));
                }
            }
            return numero+numeroFlotante;
        }
    }
}
