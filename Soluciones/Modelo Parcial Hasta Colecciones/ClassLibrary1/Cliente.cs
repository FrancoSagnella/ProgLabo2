using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cliente
    {
        private string aliasParaisoIncognito;
        private string nombre;
        private ETipoCliente tipoDeCliente;

        //Constructores
        private Cliente()
        {
            this.nombre = "NN";
            this.aliasParaisoIncognito = "Sin Alias";
            this.tipoDeCliente = ETipoCliente.SinTipo;
        }
        public Cliente(ETipoCliente tipoCliente):this()
        {
            this.tipoDeCliente = tipoCliente;
        }
        public Cliente(ETipoCliente tipoCliente, string nombre):this(tipoCliente)
        {
            this.nombre = nombre;
        }
        //Metodos
        private void CrearAlias()
        {
            Random aux = new Random();
            this.aliasParaisoIncognito = (aux.Next(1000, 9999).ToString() + this.tipoDeCliente.ToString());
        }
        public string GetAlias()
        {
            if (this.aliasParaisoIncognito == "Sin Alias")
            {
                this.CrearAlias();
            }

            return this.aliasParaisoIncognito;
        }
        private string RetornarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Nombre: ");
            sb.AppendLine(this.nombre);
            sb.Append("Tipo: ");
            sb.AppendLine(this.tipoDeCliente.ToString());
            sb.Append("Alias: ");
            sb.Append(this.GetAlias());

            return sb.ToString();
        }
        public static string RetornarDatos(Cliente unCliente)
        {
            return unCliente.RetornarDatos();
        }
    }
}
