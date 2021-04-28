using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_29
{
    public class Jugador
    {
        private int dni;
        private string nombre;
        private int partidosJugados;
        private int totalGoles;

        public int PartidosJugados
        {
            get
            {
                return this.partidosJugados;
            }
        }
        public float Promediogoles
        {
            get
            {
                if (this.partidosJugados == 0)
                    return 0;

                return this.totalGoles / this.partidosJugados;
            }
        }
        public int TotalGoles
        {
            get
            {
                return this.totalGoles;
            }
        }
        private Jugador()
        {
            this.dni = 0;
            this.nombre = "Sin Nombre";
            this.partidosJugados = 0;
            this.totalGoles = 0;
        }
        public Jugador(int dni, string nombre) : this()
        {
            this.dni = dni;
            this.nombre = nombre;
        }
        public Jugador(int dni, string nombre, int totalGoels, int totalPartidos):this(dni, nombre)
        {
            this.totalGoles = totalGoels;
            this.partidosJugados = totalPartidos;
        }
        public string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("DNI: {0}\n", this.dni);
            sb.AppendFormat("Nombre: {0}\n", this.nombre);
            sb.AppendFormat("Partidos Jugados: {0}\n", this.partidosJugados);
            sb.AppendFormat("Total de Goles: {0}\n", this.totalGoles);
            sb.AppendFormat("Promedio de Goles: {0}\n", this.Promediogoles);

            return sb.ToString();
        }
        public static bool operator ==(Jugador j1, Jugador j2)
        {
            bool retorno = false;
            if(j1.dni == j2.dni)
            {
                retorno = true;
            }
            return retorno;
        }
        public static bool operator !=(Jugador j1, Jugador j2)
        {
            return !(j1 == j2);
        }
    }
}
