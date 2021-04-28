using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_16
{
    class Alumno
    {
        private byte nota1;
        private byte nota2;
        private float notaFinal;
        public string apellido;
        public int legajo;
        public string nombre;

        public Alumno(string apellido, int legajo, string nombre)
        {
            this.apellido = apellido;
            this.legajo = legajo;
            this.nombre = nombre;
        }
        public void CalcularFinal()
        {
            if(this.nota1 >= 4 && this.nota2 >= 4)
            {
                Random generador = new Random();
                this.notaFinal = generador.Next(1, 10);
            }
            else
            {
                this.notaFinal = -1;
            }
        }
        public void Estudiar(byte notaUno, byte notaDos)
        {
            this.nota1 = notaUno;
            this.nota2 = notaDos;
        }
        public void Mostrar()
        {
            Console.WriteLine("Apellido: {0}\nNombre: {1}\nLegajo: {2}\nNota1: {3}\nNota2: {4}", this.apellido, this.nombre, this.legajo, this.nota1, this.nota2);
            if(this.notaFinal != -1)
            {
                Console.WriteLine("nota final: {0}", this.notaFinal);
            }
            else
            {
                Console.WriteLine("Alumno desaprobado");
            }
        }
    }
}
