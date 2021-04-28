using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace Eventos.WindowsForm
{
    public partial class frmEmpleados : Form
    {
        private Empleado miEmpleado;

        public frmEmpleados()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
        #region Manejadores 'Estáticos'

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            this.CargarCombo();
            this.cboManejadores.SelectedIndex = 0;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.miEmpleado = new Empleado();

            this.AsignarManejadores();
            
            this.miEmpleado.Nombre = this.txtNombre.Text;
            this.miEmpleado.Sueldo = double.Parse(this.txtSueldo.Text);
        }

        #endregion

        #region Manejadores 'Dinámicos'

        public void SobreAsignacionSueldo(Double importe, Empleado e)
        {
            MessageBox.Show("Se intentó asignar al empleado " + e.Nombre + " el sueldo de " +
                            importe.ToString() + (Char)(Keys.Enter) + "¡ESTO ES INCORRECTO!", "ATENCIÓN", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        public void SalarioIncorrecto(Double importe, Empleado e)
        {
            MessageBox.Show("INFORME DE INCIDENCIAS"+(Char)(Keys.Enter) +
                            "======================"+(Char)(Keys.Enter) +
                            "Error al intentar asignar el salario de " +
                            importe.ToString()+ " al empleado "+ e.Nombre, "ATENCIÓN",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        #endregion

        #region Métodos privados

        private void CargarCombo() 
        {
            foreach (TipoManejador item in Enum.GetValues(typeof(TipoManejador)))
            {
                this.cboManejadores.Items.Add(item); 
            }
        }

        private void AsignarManejadores()
        {
            TipoManejador queTipo;
            
            queTipo = (TipoManejador)this.cboManejadores.SelectedItem;

            switch (queTipo)
            {
                case TipoManejador.Ambos:
                    this.miEmpleado.LimiteSueldo += new LimiteSueldoDel(SobreAsignacionSueldo);
                    this.miEmpleado.LimiteSueldo += new LimiteSueldoDel(SalarioIncorrecto);
                    break;
                case TipoManejador.SalarioIncorrecto:
                    this.miEmpleado.LimiteSueldo += new LimiteSueldoDel(SalarioIncorrecto);
                    break;
                case TipoManejador.SobreAsignacionSueldo:
                    this.miEmpleado.LimiteSueldo += new LimiteSueldoDel(SobreAsignacionSueldo);
                    break;
            }
        }

        #endregion
    }
}
