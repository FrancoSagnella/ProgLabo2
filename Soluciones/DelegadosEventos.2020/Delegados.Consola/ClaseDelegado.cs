using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegados.Consola
{
    public class ClaseDelegado
    {
        #region Metodos con la misma firma del Delegado

        public void Dividir(int numero1, int numero2)
        {
            Console.WriteLine("La División es: {0}", numero1 / numero2);
        }

        public static void Multiplicar(int numero1, int numero2)
        {
            Console.WriteLine("La Multiplicación es: {0}", numero1 * numero2);
        }

        #endregion

        #region Metodo con otra firma pero que utiliza al Delegado

        public void Calcular(int numero1, DelegadoDeMiFuncion operador, int numero2)
        {
            //INVOCO AL METODO
            operador.Invoke(numero1, numero2);
        }

        #endregion

    }
}
