using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesBD;

namespace _02_DataAdapter
{
    public partial class frmPersona : Form
    {
        protected Persona p;

        public Persona Persona
        {
            get { return this.p; }
        }

        public frmPersona()
        {
            InitializeComponent();

        }

        public frmPersona(Persona p) : this()
        {
            this.p = p;

            this.txtNombre.Text = p.Nombre;
            this.txtApellido.Text = p.Apellido;
            this.txtEdad.Text = p.Edad.ToString();
            this.txtId.Text = p.ID.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string id = this.txtId.Text;
            id = id == "" ? "0" : id;

            this.p = new Persona(int.Parse(id), this.txtNombre.Text, this.txtApellido.Text, int.Parse(this.txtEdad.Text));

            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
