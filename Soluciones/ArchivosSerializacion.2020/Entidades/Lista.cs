using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lista<T>
    {
        private List<T> items;

        public List<T> Items
        {
            get { return this.items; }
        }

        public Lista()
        {
            this.items = new List<T>();
        }
    }
}
