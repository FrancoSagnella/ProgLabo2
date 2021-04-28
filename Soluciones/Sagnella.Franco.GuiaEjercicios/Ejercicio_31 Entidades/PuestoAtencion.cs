using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_31_Entidades
{
    public enum Puesto
    {
        caja1,
        caja2
    }
    public class PuestoAtencion
    {
        static private int numeroActual;
        public Puesto puesto;

        static PuestoAtencion()
        {
            PuestoAtencion.numeroActual = 0;
        }
        public PuestoAtencion(Puesto puesto)
        {
            this.puesto = puesto;
        }

        public bool Atender(Cliente cli)
        {
            Thread.Sleep(1000);
            return true;
        }
        public static int NumeroActual 
        {
            get
            {
                return PuestoAtencion.numeroActual++;
            }
        }
    }
}
