using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Capitulo
    {
        #region Atributos

        private int numero;
        private string titulo;
        private static int ultimoCapitulo;

        #endregion

        #region Propiedades

        public int Numero
        {
            get { return this.numero; }
        }

        public string Titulo
        {
            get { return this.titulo; }
        }

        #endregion

        #region Constructores

        static Capitulo()
        {
            Capitulo.ultimoCapitulo = 1;
        }

        private Capitulo(int numero, string titulo) 
        {
            Capitulo.ultimoCapitulo++;
            this.numero = numero;
            this.titulo = titulo;
        }

        #endregion

        #region Sobrecarga operadores

        public static implicit operator Capitulo(string titulo)
        {

            return new Capitulo(Capitulo.ultimoCapitulo, titulo);
        }

        #endregion
    }
}
