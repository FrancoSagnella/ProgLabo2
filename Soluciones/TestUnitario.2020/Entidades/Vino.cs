using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Representa a los distintos vinos.
    /// </summary>
    public class Vino
    {
        private ETipoVino tipoVino;
        private EBodega bodega;

        #region Constructor

        /// <summary>
        /// Crea un objeto de tipo Vino.
        /// </summary>
        /// <param name="tipo">Enumerado que representa los distintos tipos de vinos.</param>
        /// <param name="bodega">Enumerado que representa las distintas bodegas.</param>
        public Vino(ETipoVino tipo, EBodega bodega)
        {
            this.tipoVino = tipo;
            this.bodega = bodega;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que retorna la representación del objeto en formato String.
        /// </summary>
        /// <returns>La cadena que representa el objeto.</returns>
        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Tipo: ");
            sb.AppendLine(this.tipoVino.ToString());
            sb.AppendFormat("Bodega: {0}", this.bodega.ToString());
            sb.AppendLine();

            return sb.ToString();
        }

        #endregion

        #region Sobrecarga Operadores

        /// <summary>
        /// Compara dos objetos de tipo Vino, según su tipo y bodega.
        /// </summary>
        /// <param name="v1">Primer objeto a ser comparado.</param>
        /// <param name="v2">Segundo objeto a ser comparado.</param>
        /// <returns>True, si son iguales. False, caso contrario.</returns>
        public static bool operator ==(Vino v1, Vino v2)
        {
            bool rta = false;

            #region "Código original"

            ////Si ambos parámetros son null, no comparo por atributos
            //if (((object)v1) == null && ((object)v2) == null)
            //{
            //    rta = true;
            //}
            //else //v1 != null y v2 != null; v1 != null y v2 == null; v1 == null y v2 != null
            //{
            //    if (((object)v1) != null && ((object)v2) != null)
            //    {
            //        if (v1.tipoVino == v2.tipoVino && v1.bodega == v2.bodega)
            //        {
            //            rta = true;
            //        }
            //    }
            //    //si alguno de los parámetros es != null y el otro no, retorno false
            //}
            #endregion

            #region Código modificado

            if (v1.tipoVino == v2.tipoVino && v1.bodega == v2.bodega)
            {
                rta = true;
            }

            #endregion

            return rta;
        }

        /// <summary>
        /// Compara dos objetos de tipo Vino, según su tipo y bodega.
        /// </summary>
        /// <param name="v1">Primer objeto a ser comparado.</param>
        /// <param name="v2">Segundo objeto a ser comparado.</param>
        /// <returns>True, si son distintos. False, caso contrario.</returns>
        public static bool operator !=(Vino v1, Vino v2)
        {
            return ! (v1 == v2);
        }

        #endregion

    }
}
