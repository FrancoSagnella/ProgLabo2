using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _02_DataAdapter
{
    static class Program
    {         
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmPrincipal frm = new frmPrincipal();

            try
            {
                Application.Run(frm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
    }
}
