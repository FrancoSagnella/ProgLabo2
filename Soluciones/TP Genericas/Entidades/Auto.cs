using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Auto
    {
        private string color;
        private string marca;

        public string Marca 
        { 
            get
            {
                return this.marca;
            }
        }
        public string Color
        {
            get
            {
                return this.color;
            }
        }
        public Auto(string color, string marca)
        {
            this.color = color;
            this.marca = marca;
        }
        public static bool operator ==(Auto a1, Auto a2)
        {
            bool ret = false;
            if(a1.color == a2.color && a1.marca == a2.marca)
            {
                ret = true;
            }
            return ret;
        }
        public static bool operator !=(Auto a1, Auto a2)
        {
            return !(a1 == a2);
        }
        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Auto)
            {
                ret = (Auto)obj == this;
            }
            return ret;
        }
        public override string ToString()
        {
            return String.Format("Marca: {0} - Color: {1}", this.marca, this.color);
        }
    }
}
