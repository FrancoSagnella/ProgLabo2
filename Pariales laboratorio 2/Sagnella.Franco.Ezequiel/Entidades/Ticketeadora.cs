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
        public static bool ImprimirTicket(double dato)
        {
            bool ret = true;
            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", true))
                {
                    sw.WriteLine("Fecha: {0}", DateTime.Now);
                    sw.WriteLine("Precio Total: {0}", dato);
                    sw.WriteLine("-------------------------");
                }
            }
            catch (Exception e)
            {
                ret = false;
            }

            return ret;
        }
    }
}
