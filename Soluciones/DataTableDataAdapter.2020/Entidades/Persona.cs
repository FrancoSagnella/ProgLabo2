using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Persona(int id, string nombre, string apellido, int edad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }

        public override string ToString()
        {
            return this.Id.ToString() + " - " + this.Nombre + " - " + this.Apellido + " - " + this.Edad.ToString();
        }
    }
}
