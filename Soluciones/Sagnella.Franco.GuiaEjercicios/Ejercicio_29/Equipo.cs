using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_29
{
    public class Equipo
    {
        private short cantidadJugadores;
        public List<Jugador> jugadores;
        private string nombre;

        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }
        public Equipo(short cantidad, string nombre):this()
        {
            this.cantidadJugadores = cantidad;
            this.nombre = nombre;
        }
        public static bool operator +(Equipo e, Jugador j)
        {
            bool retorno = false;
            if((e.jugadores.Count != e.cantidadJugadores))
            {
                retorno = true;
                foreach(Jugador item in e.jugadores)
                {
                    if(item == j)
                    {
                        retorno = false;
                        break;
                    }
                }
            }
            if(retorno == true)
            {
                e.jugadores.Add(j);
            }
            return retorno;
        }
    }
}
