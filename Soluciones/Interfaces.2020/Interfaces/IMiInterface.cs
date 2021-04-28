using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IMiInterface
    {

        #region Propiedades

        int PropiedadLE { get; set; }
        int PropiedadSL { get; }
        int PropiedadSE { set; }

        #endregion

        #region Métodos

        void MetodoSinRetornoNiParametros();
        double MetodoConParametros(int uno, int dos);

        #endregion

    }
}
