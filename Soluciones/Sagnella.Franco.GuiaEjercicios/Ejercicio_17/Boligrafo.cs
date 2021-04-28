using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioLapiceras
{
    public class Boligrafo
    {
        private const short cantidadTintaMaxima = 100;
        private ConsoleColor color;
        private short tinta;

        public Boligrafo(short tinta, ConsoleColor color)
        {
            this.tinta = tinta;
            this.color = color;
        }
        public ConsoleColor GetColor()
        {
            return this.color;
        }
        public short GetTinta()
        {
            return this.tinta;
        }
        public bool Pintar(short gasto, out string dibujo)
        {
            bool retorno = false;
            dibujo = "";
            short tinta = GetTinta();
            SetTinta((short)-gasto);
            short nuevoNivelTinta = GetTinta();

            Console.ForegroundColor = ConsoleColor.White;

            if (tinta > 0)
            {
                if(nuevoNivelTinta < 0)
                {
                    nuevoNivelTinta = 0;
                }
                for(int i = nuevoNivelTinta; i < tinta; i++)
                {
                    dibujo += "*";
                }
                Console.ForegroundColor = this.GetColor();
                retorno = true;
            }
            return retorno;
        }
        public void Recargar()
        {
            this.SetTinta((short)(cantidadTintaMaxima - this.tinta));
        }
        private void SetTinta(short tinta)
        {
            short auxCarga = (short)(this.tinta + tinta);
            if(auxCarga >= 0 && auxCarga <= cantidadTintaMaxima)
            {
                this.tinta = auxCarga;
            }
            else if(auxCarga < 0)
            {
                this.tinta = 0;
            }
            else
            {
                this.tinta = 100;
            }
        }
    } 
}
