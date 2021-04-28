using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
namespace Entidades
{
    public class Manejadora
    {
        public void ImprimirTicket_EventoPrecio(double precio)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Tickets.txt", true))
                {
                    sw.Write("Fecha: ");
                    sw.WriteLine(DateTime.Now);
                    sw.Write("Precio: ");
                    sw.WriteLine(precio);
                    sw.WriteLine("-----------------");
                }
            }catch(Exception e)
            {
                throw new Exception("Error al imprimir el ticket");
            }
        }
    }
}
