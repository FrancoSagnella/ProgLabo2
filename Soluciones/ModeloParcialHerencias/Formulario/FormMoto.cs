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
    public partial class FormMoto : FormVehiculo
    {
        private Moto miMoto;

        public Moto MiMoto
        {
            get
            {
                return this.miMoto;
            }
        }
        public FormMoto()
        {
            InitializeComponent();
        }
        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this.miMoto = new Moto(base.txtPatente.Text, byte.Parse(base.txtCantRuedas.Text),
                                    (EMarcas)base.cmbMarca.SelectedItem, float.Parse(this.txtCilindrada.Text));

            this.DialogResult = DialogResult.OK;
        }
    }
}
