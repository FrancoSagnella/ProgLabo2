using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_22Clases
{
    public class Conversor
    {
        private static bool EsBinario(string binario)
        {
            int largo = binario.Length;
            bool retorno = true;

            if (binario != null && binario != "")
            {
                for (int i = 0; i < largo; i++)
                {
                    if (binario[i] != '1' && binario[i] != '0')
                    {
                        retorno = false;
                        break;
                    }
                }
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }
        public static string BinarioDecimal(string binario)
        {
            string retorno;
            int largo = binario.Length;
            int numAux;
            double numResult = 0;

            if (Conversor.EsBinario(binario))
            {
                for (int i = 1; i <= largo; i++)
                {
                    numAux = binario[i - 1] - '0';//'0' es 48, al restarlo con cualquier numero, por ejemplo '9' es 57, entonces 57 - 48 = 9
                                                  //i-1 porque quiero el indice 0
                    numResult += (numAux * Math.Pow(2, largo - i));//Elevo el caracter 0 o 1 por la posicion en la que esta, 
                                                                   //pongo - i porque quiero que sea 4, despues 3, 2, 1, 0
                }
                retorno = numResult.ToString();
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }
        public static string DecimalBinario(double numero)
        {
            int resultado = (int)(Math.Abs(numero));//Tomo el valor absoluto casteado como entero
                                                    //Si llegase a ser negativo con el valor absoluto puedo operar igual
            string binario = "";

            if (resultado > 0)
            {
                while (resultado > 0)
                {
                    if (resultado % 2 == 0)
                    {
                        binario = "0" + binario;//no puedo hacer +=, tiene que ser asi, para que el 0 o el 1 se pongan a la izquierda
                    }
                    else
                    {
                        binario = "1" + binario;
                    }
                    resultado = (int)(resultado / 2);
                }
            }
            else if (resultado == 0)
            {
                binario = "0";
            }

            return binario;
        }
        public static string DecimalBinario(string numero)
        {
            string retorno;
            double valor;
            if (double.TryParse(numero, out valor) && numero != null)//Para validar si la string que me viene es un numero
            {
                retorno = Conversor.DecimalBinario(valor);
            }
            else
            {
                retorno = "Valor invalido";
            }
            return retorno;
        }
    }
}
