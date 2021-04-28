using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesBD;

namespace WindowsFormsBD
{
    public partial class ABM : Form
    {
        #region Atributo

        private Persona persona;

        #endregion

        #region Propiedad (sólo lectura)
        public Persona PersonaDelFormulario
        {
            get { return persona; }
        }

        #endregion

        #region Constructor
        public ABM()
        {
            InitializeComponent();
        }

        public ABM(Persona p) : this()
        {
            this.persona = p;
            this.txtApellido.Text = this.persona.Apellido;
            this.txtNombre.Text = this.persona.Nombre;
            this.txtEdad.Text = this.persona.Edad.ToString();
        }

        #endregion

        #region Métodos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int idPersona = this.persona != null ? this.persona.ID : 0;

            this.persona = new Persona(idPersona, this.txtApellido.Text, this.txtNombre.Text, int.Parse(this.txtEdad.Text));

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
