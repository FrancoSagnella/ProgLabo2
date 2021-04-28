using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro
    {
        #region Atributos

        private string titulo;
        private string autor;
        private List<Capitulo> capitulos;

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
                return this.capitulos.Count;
            }
        }

        #endregion

        #region Constructor

        public Libro(string titulo, string autor)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.capitulos = new List<Capitulo>();
        }

        #endregion

        #region Indexador

        public Capitulo this[int indice]
        {
            get
            {
                if (indice >= this.capitulos.Count || indice < 0)
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
                if (indice >= 0 && indice < this.capitulos.Count)
                {
                    this.capitulos[indice] = value;
                }                   
                else if (indice == this.capitulos.Count)
                {
                    this.capitulos.Add(value);
                }                   
                else
                {
                    Console.WriteLine("No se puede asignar a este elemento");
                }
            }
        }

        #endregion
    }
}
