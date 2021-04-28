using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Binario
{

    //Con este atributo indico que la clase 
    //se puede serializar a Binario
    //La clase puede o no ser pública
    [Serializable]
    class DatoBinario
    {
        public string nombre;
        public int edad;
        protected int dni;
        private string apodo;

        //El constructor por defecto es requerido 
        //para poder serializar en binario
        public DatoBinario()
        {

        }

        public DatoBinario(string nombre, int edad, int dni, string apodo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = dni;
            this.apodo = apodo;
        }

        public override string ToString()
        {
            StringBuilder cadena = new StringBuilder();

            cadena.Append("Nombre: ");
            cadena.AppendLine(this.nombre);
            cadena.Append("Edad: ");
            cadena.AppendLine(this.edad.ToString());
            cadena.Append("Dni: ");
            cadena.AppendLine(this.dni.ToString());
            cadena.Append("Apodo: ");
            cadena.AppendLine(this.apodo);

            return cadena.ToString();
        }
    }
}
