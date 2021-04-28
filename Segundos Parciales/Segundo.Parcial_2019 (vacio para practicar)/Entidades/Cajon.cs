using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;

namespace Entidades.SP
{
    //Decalro el delegado
    public delegate void DelegadoPrecio(double precio);
    public class Cajon<T> where T : Fruta , ISerializar
    {
        protected int capacidad;
        protected List<T> elementos;
        protected double precioUnitario;

        public int Capacidad
        {
            get
            {
                return this.capacidad;
            }
        }
        //Declaro el evento con la firma del delegado
        public event DelegadoPrecio EventoPrecio;

        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }
        public double PrecioTotal
        {
            get
            {
                 return  this.precioUnitario * this.elementos.Count;
            }
        }

        public Cajon()
        {
            this.elementos = new List<T>();
            this.capacidad = 0;
            this.precioUnitario = 0;
        }
        public Cajon(int cap)
            :this()
        {
            this.capacidad = cap;
        }
        public Cajon(double precio, int cap)
            :this(cap)
        {
            this.precioUnitario = precio;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Capacidad: ");
            sb.AppendLine(this.capacidad.ToString());
            sb.Append("Cantidad de elementos: ");
            sb.AppendLine(this.elementos.Count.ToString());
            sb.Append("Precio total: ");
            sb.AppendLine(this.PrecioTotal.ToString());

            foreach(T item in this.elementos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        public static Cajon<T> operator +(Cajon<T> c, T f)
        {
            if(c.elementos.Count < c.capacidad)
            {
                c.elementos.Add(f);

                double aux = c.PrecioTotal;
                if (aux > 55)
                {
                    c.EventoPrecio(aux);
                }
            }
            else
            {
                throw new CajonLlenoException();
            }
            return c;
        } 

        public bool Xml(string path)
        { 
            bool ret = true;
            try
            {
                using (StreamWriter wr = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\"+path))
                {
                    XmlSerializer se = new XmlSerializer(typeof(Cajon<T>));
                    se.Serialize(wr, this);
                }
            }
            catch(Exception e)
            {
                ret = false;
            }
            return ret;
        }
    }
}
