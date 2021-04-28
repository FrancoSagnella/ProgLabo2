using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Ticketadora
    {
        public static bool ImprimirTicket(double e)
        {
            bool ret = true;

            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log";
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("Fecha: {0}", DateTime.Now);
                    sw.WriteLine("Precio Total: {0}", e);
                    sw.WriteLine("-------------------------");
                }
            }
            catch(Exception ex)
            {
                ret = false;
                return ret;
            }
            return ret;
        }
    }
}
