using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Grupo
    {
        private List<Mascota> manada;
        private string nombre;
        private static ETipoManada tipo;

        static Grupo()
        {
            Grupo.Tipo = ETipoManada.Unica;
        }
        private Grupo()
        {
            this.manada = new List<Mascota>();
        }
        public Grupo(string nombre) : this()
        {
            this.nombre = nombre;
        }
        public Grupo(string nombre, ETipoManada tipo):this(nombre)
        {
            this.nombre = nombre;
            Grupo.Tipo = tipo;
        }

        public static ETipoManada Tipo
        {
            set
            {
                Grupo.tipo = value;
            }
        }

        public static bool operator ==(Grupo g, Mascota m)
        {
            bool retorno = false;
            foreach(Mascota item in g.manada)
            {
                if(item.Equals(m))
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Grupo g, Mascota m)
        {
            return !(g == m);
        }
        public static Grupo operator +(Grupo g, Mascota m)
        {
            if(g != m)
            {
                g.manada.Add(m);
            }
            else
            {
                Console.WriteLine("Ya esta '{0}' en el grupo", m.ToString());
            }
            return g;
        }
        public static Grupo operator -(Grupo g, Mascota m)
        {
            if(g == m)
            {
                //g.manada.RemoveAt(g.manada.IndexOf(m));
                g.manada.Remove(m);
                //Puedo usar el remove, porque como sobrecargue el equals
                //de perro y gato, los va a comparar con eso
            }
            else
            {
                Console.WriteLine("No esta '{0}' en el grupo", m.ToString());
            }
            return g;
        }
        public static implicit operator string(Grupo g)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Grupo: ");
            sb.AppendFormat("{0} - tipo: {1}\n", g.nombre, Grupo.tipo);
            sb.AppendFormat("Integrantes: {0}\n", g.manada.Count());
            
            foreach(Mascota item in g.manada)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
