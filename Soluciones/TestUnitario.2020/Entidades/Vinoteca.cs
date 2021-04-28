using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vinoteca
    {
        private int capacidad;
        private Vino[] vinos;

        #region Constructor

        /// <summary>
        /// Crea una instancia de tipo Vinoteca.
        /// </summary>
        /// <param name="capacidad">Indica la capacidad máxima que posee la vinoteca.</param>
        public Vinoteca(int capacidad)
        {
            this.capacidad = capacidad;
            this.vinos = new Vino[this.capacidad];
        }

        //se agrega sobrecarga
        /// <summary>
        /// Crea una instancia de tipo Vinoteca. Cantidad por defecto, 3.
        /// </summary>
        public Vinoteca()
        {
        }
        #endregion

        #region Propiedades

        //se agrega propiedad de sólo lectura
        public Vino[] Vinos
        { 
            get { return this.vinos; }
        }

        //se agrega propiedad de sólo lectura
        public Int32 EspacioLibre
        {
            get { return this.ObtenerCantidadLugaresLibres(); }
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

            sb.Append("Capacidad: ");
            sb.AppendLine(this.capacidad.ToString());
            sb.AppendLine("Listado de vinos:");

            foreach (Vino item in this.vinos)
            {
                //Si el lugar no está vacío, lo muestro.
                if (item != null)
                {
                    sb.AppendLine(item.Mostrar());
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Obtiene el primer lugar disponible de la vinoteca.
        /// </summary>
        /// <returns>Retorna el valor del índice del lugar encontrado. 
        /// Su valor será negativo si no hay lugar disponible.
        /// </returns>
        private int ObtenerLugar()
        {
            int indice = -1;

            for (int i = 0; i < this.vinos.Length; i++)
            {
                if (this.vinos[i] == null)
                {
                    indice = i;
                    break;
                }
            }

            return indice;
        }

        private int ObtenerCantidadLugaresLibres()
        {
            int cantidadLugaresLibres = 0;

            for (int i = 0; i < this.vinos.Length; i++)
            {
                if (this.vinos[i] == null)
                {
                    cantidadLugaresLibres++;
                }
            }

            return cantidadLugaresLibres;
        }

        #endregion

        #region Sobrecarga de operadores

        /// <summary>
        /// Agrega un vino a la vinoteca, si posee al menos un lugar libre.
        /// </summary>
        /// <param name="vt">Representa a la vinoteca que agregará el vino.</param>
        /// <param name="v">Indica el vino que se agregará a la vinoteca.</param>
        /// <returns>Retorna la vinoteca con el vino agregado (o no)</returns>
        public static Vinoteca operator +(Vinoteca vt, Vino v)
        {
            int i = vt.ObtenerLugar();

            if (i > -1)
            {
                vt.vinos[i] = v;
            }
            else
            {
                throw new Exception("Vinoteca llena!!!");
            }

            return vt;
        }

        #endregion

    }
}
