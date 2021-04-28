using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_DataAdapter
{
    public class Producto
    {
        public Int32 idProducto;
        public String descripcion;

        public Int32 IdProducto
        {
            get { return this.idProducto; }
            set { this.idProducto = value; }
        }

        public String Descripcion 
        {
            get { return this.descripcion; }
            set { this.descripcion = value; } 
        }

        public Producto(Int32 id, String desc)
        {
            this.idProducto = id;
            this.descripcion = desc;
        }
    }
}
