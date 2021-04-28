using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eventos.Entidades
{
    //DECLARO UN DELEGADO
    public delegate void LimiteSueldoDelegadoMejorado(EmpleadoMejorado sender, EmpleadoEventArgs e);

    /// <summary>
    /// Clase que sera el 'emisor' del evento
    /// </summary>
    public class EmpleadoMejorado
    {
        //DECLARO UN EVENTO
        public event LimiteSueldoDelegadoMejorado LimiteSueldo;

        #region Atributos

        protected String nombre;
        protected Double sueldo;

        #endregion

        #region Propiedades

        public String Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }
        public Double Sueldo
        {
            get { return this.sueldo; }
            set
            {
                //SI EL VALOR SUPERA AL PERMITIDO...
                if (value > 20000)
                {
                    //CREO UN OBJETO EMPLEADOEVENTARGS Y LE PASO A SUS PROPIEDADES
                    //INFORMACION SOBRE EL EVENTO.
                    //EN ESTE CASO SOLO PASO EL VALOR INCORRECTO QUE SE INTENTO ASIGNAR
                    EmpleadoEventArgs miEventArgs = new EmpleadoEventArgs();
                    
                    miEventArgs.SueldoIntentadoAsignar = value;

                    //DESPUES LANZO EL EVENTO Y LE PASO COMO PARAMETRO EL PROPIO
                    //OBJETO CON LA INFORMACION DEL EVENTO
                    this.LimiteSueldo(this, miEventArgs);
                }
                else
                {
                    this.sueldo = value;
                }
            }
        }

        #endregion
    }
}
