using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesBD
{
    public class Persona
    {

        #region Atributos

        private int id;
        private string nombre;
        private string apellido;
        private int edad;

        #endregion

        #region Propiedades

        public Int32 ID
        {
            get
            {
                return this.id;
            }
        }
        public String Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public String Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = value;
            }
        }
        public Int32 Edad
        {
            get
            {
                return this.edad;
            }
            set
            {
                this.edad = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una persona
        /// </summary>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        public Persona(string apellido, string nombre, int edad)
        {
            this.apellido = apellido;
            this.nombre = nombre;
            this.edad = edad;
        }

        /// <summary>
        /// Inicializa una persona
        /// </summary>
        /// <param name="ID">ID de la persona en la BD</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="edad">Edad de la persona</param>
        public Persona(int ID, string apellido, string nombre, int edad)
            : this(apellido, nombre, edad)
        {
            this.id = ID;
        }

        #endregion

    }
}
