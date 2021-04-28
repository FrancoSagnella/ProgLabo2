using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clase_7_Entidades
{
    public class Paleta
    {
        private Tempera[] temperas;
        private int cantMaxColores;

        public Paleta():this(5)
        {
            this.temperas = new Tempera[this.cantMaxColores];
        }
        public Paleta(int cant)
        {
            this.cantMaxColores = 5;
        }

        private string Mostrar()
        {
            StringBuilder aux = new StringBuilder();

            aux.Append("Capacidad: ");
            aux.AppendLine(this.cantMaxColores.ToString());
            aux.AppendLine("Temperas: ");
            
            foreach(Tempera t in this.temperas)
            {
                if(t != null)
                {
                    aux.Append(Tempera.Mostrar(t));
                }
            }
            return aux.ToString();
        }
        public static implicit operator int(Paleta p)
        {
            return p.cantMaxColores;
        }
        public static explicit operator string(Paleta p)
        {
            return p.Mostrar();
        }

        public static bool operator ==(Paleta p, Tempera t)
        {
            bool retorno = false;

            foreach(Tempera item in p.temperas)
            {
                if(item == t)
                {
                    retorno = true;
                    break;
                }
            }
            return retorno;
        }
        public static bool operator !=(Paleta p, Tempera t)
        {
            return !(p == t);
        }

        private int ObtenerIndice()
        {
            return this.ObtenerIndice(null);
        }
        private int ObtenerIndice(Tempera t)
        {
            int index = -1;
            int len = this.temperas.Length;

            for(int i = 0; i < len; i++)
            {
                if(this.temperas[i] == t)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public static Paleta operator +(Paleta p, Tempera t)
        {
            int index;
            if (p == t)
            {
                index = p.ObtenerIndice(t);

                if(index > -1)
                    p.temperas[index] += t;
            }
            else
            {
                index = p.ObtenerIndice();

                if (index > -1)
                    p.temperas[index] = t;
            }
            return p;
        }
        //public static Paleta operator +(Paleta p1, Paleta p2)
        //{
        //}
        public static Paleta operator -(Paleta p, Tempera t)
        {
            int index;
            if (p == t)
            {
                index = p.ObtenerIndice(t);

                if (index > -1)
                {
                    p.temperas[index] -= t;

                    if(p.temperas[index] <= 0)
                    {
                        p.temperas[index] = null;
                    }
                }
                    
            }
            return p;
        }
    }
}
