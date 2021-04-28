using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_31_Entidades
{
    public class Negocio
    {
        private PuestoAtencion caja;
        private Queue<Cliente> clientes;
        private string nombre;

        public Cliente Clietne
        {
            get
            {
                return this.clientes.Peek();
            }
            set
            {
                bool i = this + value;
            }
        }
        private Negocio()
        {
            this.clientes = new Queue<Cliente>();
            this.caja = new PuestoAtencion(Puesto.caja1);
        }
        public Negocio(string nombre):this()
        {
            this.nombre = nombre;
        }
        public static bool operator +(Negocio n, Cliente c)
        {
            bool ret = false;
            if (n != c)
            {
                n.clientes.Enqueue(c);
                ret = true;
            }
            return ret;
        }
        public static bool operator ==(Negocio n, Cliente c)
        {
            bool ret = false;
            foreach(Cliente item in n.clientes)
            {
                if(item == c)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        public static bool operator !=(Negocio n, Cliente c)
        {
            return !(n == c);
        }
    }
}
