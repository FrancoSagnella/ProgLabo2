using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_15
{
    class Calculadora
    {
        public static double resultado;
        public static double primerOperador;
        public static double segundoOperador;
        public static char operador;

        public static bool Calcular(double num1, double num2, char operador)
        {
            bool retorno = true;
            switch(operador)
            {
                case '+':
                    Calculadora.resultado = num1 + num2;
                    break;
                case '-':
                    Calculadora.resultado = num1 - num2;
                    break;
                case '*':
                    Calculadora.resultado = num1 + num2;
                    break;
                case '/':
                    if(Calculadora.Validar(num2))
                    {
                        Calculadora.resultado = num1 / num2;
                    }
                    else
                    {
                        retorno = false;
                    }
                    break;
                default:
                    retorno =  false;
                    break;
            }
            return retorno;
        }
        private static bool Validar(double num)
        {
            bool retorno = false;
            if(num != 0)
            {
                retorno = true;
            }
            return retorno;
        }
    }
}
