using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario
{
    public partial class FormAuto : FormVehiculo
    {
        private Auto miAuto;

        public Auto MiAuto
        {
            get
            {
                return this.miAuto;
            }
        }
        public FormAuto()
        {
            InitializeComponent();
        }
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.miAuto = new Auto(base.txtPatente.Text, byte.Parse(base.txtCantRuedas.Text),
                                    (EMarcas)base.cmbMarca.SelectedItem, int.Parse(this.txtCantAsientos.Text));

            this.DialogResult = DialogResult.OK;
        }
    }
}
