using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace TestUnitarios.ClassLibrary
{
    public class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        #region "Constructor"
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region "Propiedades"

        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.dni = Persona.ValidarDni(this.Nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = Persona.ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = Persona.ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        #endregion

        #region "Validadores"
        /// <summary>
        /// Validará que el DNI esté dentro de los rangos permitidos
        /// </summary>
        /// <param name="dato">DNI numérico a validar</param>
        /// <returns>DNI validado si está todo OK, o 0 (cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentina:
                    if (dato < 1 || dato > 89999999)
                        throw new NacionalidadInvalidaException(dato.ToString());
                    break;
                case ENacionalidad.Extranjera:
                    if (dato < 89999999 || dato > 99999999)
                        throw new NacionalidadInvalidaException();
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Validará que el DNI sea numérico, y luego llamará a la validación numérica
        /// </summary>
        /// <param name="dato">DNI string a validar</param>
        /// <returns>DNI validado si está todo OK, o 0 (cero) en caso de error</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // Quito los . que pueda tener el número
            dato = dato.Replace(".","");
            // Compruebo que tenga al menos 1 caracter y no más de 8, dados por el número 99.999.999
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;
            //*****OPCION 1*****
            //if(!Int32.TryParse(dato, out numeroDni))
            //    throw new DniInvalidoException();
            //*****OPCION 2*****
            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch(Exception e)
            {
                throw new DniInvalidoException(dato.ToString(),e);
            }

            return Persona.ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Validará que el nombre esté compuesto solo por caracteres latinos a-z A-Z
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre o apellido validado si está todo OK, o un string vacio en caso de error</returns>
        private static string ValidarNombreApellido(string dato)
        {
            // Expresión regular para buscar solo caracteres de la a a la z minúsculas y mayúsculas con N repeticiones
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }

        #endregion
    }
}
