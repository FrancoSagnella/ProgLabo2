using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class LibroArray
    {
        #region Atributos

        private string titulo;
        private string autor;
        private Capitulo[] capitulos;

        #endregion

        #region Propiedades

        public string Titulo
        {
            get { return this.titulo; }
            set { this.titulo = value; }
        }

        public string Autor
        {
            get { return this.autor; }
            set { this.autor = value; }
        }

        public int CantidadDeCapitulos
        {
            get
            {
                return this.capitulos.GetLength(0);
            }
        }

        #endregion

        #region Constructor

        public LibroArray(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.capitulos = new Capitulo[0];
        }

        #endregion

        #region Indexador

        public Capitulo this[int indice]
        {
            get
            {
                if (indice >= this.capitulos.GetLength(0) || indice < 0)
                {
                    return null;
                }
                else
                {
                    return this.capitulos[indice];
                }                   
            }

            set
            {
                if (indice >= 0 && indice < this.capitulos.GetLength(0))
                {
                    this.capitulos[indice] = value;
                }                   
                else if (indice == this.capitulos.GetLength(0))
                {

                    this.capitulos = this + indice;
                    this[indice] = value;
                }
                else
                {
                    Console.WriteLine("No se puede asignar a este elemento");
                }
            }
        }

        public static Capitulo[] operator +(LibroArray libro, int indice)
        {
                    //CONDICION A EVALUAR               //? SI DA TRUE    //: SI DA FALSE
            int i = indice >= libro.capitulos.GetLength(0) ? ++indice : --indice;

            Capitulo[] aux = new Capitulo[i];

            libro.capitulos.CopyTo(aux, 0);

            return aux;
        }

        #endregion
    }
}
