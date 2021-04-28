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
    public partial class frmTestDelegados : Form
    {
        public frmTestDelegados()
        {
            InitializeComponent();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            frmPrincipal padre = (frmPrincipal)this.Owner;

            //INVOCO AL DELEGADO DEFINIDO EN FRMPRINCIPAL
            padre.ActualizarNombrePorDelegado(this.TxtNombre.Text);
        }
        private void ConfigurarOpenSaveFileDialog()
        {

        }

    }
}
