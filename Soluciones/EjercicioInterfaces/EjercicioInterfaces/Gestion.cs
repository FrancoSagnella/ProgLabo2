using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioInterfaces
{
    public static class Gestion
    {
        public static double MostrarImpuestoNacional(IAfip bienPunible)
        {
            return bienPunible.CalcularImpuesto();
        }
    }
}
