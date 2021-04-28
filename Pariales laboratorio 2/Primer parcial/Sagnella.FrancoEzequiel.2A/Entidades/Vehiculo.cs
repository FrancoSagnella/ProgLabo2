using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Vehiculo
    {
        protected Fabricante fabricante;
        protected static Random generadorDeVelocidades;
        protected string modelo;
        protected float precio;
        protected int velocidadMaxima;

        static Vehiculo()
        {
            Vehiculo.generadorDeVelocidades = new Random();
        }
        public Vehiculo(string marca, EPais pais, float precio, string modelo)
            :this(precio, modelo, new Fabricante(marca, pais))
        {
        }
        public Vehiculo(float precio, string modelo, Fabricante fabricante)
        {
            this.fabricante = fabricante;
            this.modelo = modelo;
            this.precio = precio;
            this.velocidadMaxima = 0;
        }
        public int VelocidadMaxima
        {
            get
            {
                if(this.velocidadMaxima == 0)
                {
                    this.velocidadMaxima = Vehiculo.generadorDeVelocidades.Next(100, 280);
                }
                return this.velocidadMaxima;
            }
        }
        private static string Mostrar(Vehiculo v)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(v.fabricante);
            sb.AppendFormat("Modelo: {0}\n", v.modelo);
            sb.AppendFormat("Velocidad maxima: {0}\n", v.VelocidadMaxima);
            sb.AppendFormat("Precio: {0}\n", v.precio);

            return sb.ToString();
        }
        public static bool operator ==(Vehiculo a, Vehiculo b)
        {
            bool ret = false;

            if(a.fabricante == b.fabricante && a.modelo == b.modelo)
            {
                ret = true;
            }

            return ret;
        }
        public static bool operator !=(Vehiculo a, Vehiculo b)
        {
            return !(a == b);
        }
        public static explicit operator string(Vehiculo v)
        {
            return Vehiculo.Mostrar(v);
        }
    }
}
