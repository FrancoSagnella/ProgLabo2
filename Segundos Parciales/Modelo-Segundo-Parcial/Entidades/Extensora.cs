using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    //Para el metodo de extension temgo que hacer una clase estatica
    public static class Extensora
    {
        //El metodo debe ser estatico pporuqe la clase lo ess, y recibir como parametro
        //this [Nombre del objeto] nombre del parametro
        //Yo lo voy a poder llamar como si fuera un metodo de instancia comun de un objeto
        //del tipo que recibe como parametro, en este caso de CartucheraLlena
        public static string InformarNovedad(this CartucheraLlenaException ex)
        {
            return ex.Message;
        }
    }
}
