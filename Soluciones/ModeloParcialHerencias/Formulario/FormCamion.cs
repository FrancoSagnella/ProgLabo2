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
    public partial class FormCamion : FormVehiculo
    {
        private Camion miCamion;

        public Camion MiCamion
        {
            get
            {
                return this.miCamion;
            }
        }
        public FormCamion()
        {
            InitializeComponent();
        }
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.miCamion = new Camion(base.txtPatente.Text, byte.Parse(base.txtCantRuedas.Text),
                                    (EMarcas)base.cmbMarca.SelectedItem, float.Parse(this.txtTara.Text));

            this.DialogResult = DialogResult.OK;
        }
    }
}
