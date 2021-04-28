using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Delegados.WindowsForm.Starter
{
    public partial class frmDatos : Form
    {
        public frmDatos()
        {
            InitializeComponent();
        }

        //METODO CON LA MISMA FIRMA DEL DELEGADO 'DELEGADODEACTUALIZACION'
        public void ActualizarNombre(string valor)
        {
            this.lblNombre.Text = valor;
        }

    }
}
