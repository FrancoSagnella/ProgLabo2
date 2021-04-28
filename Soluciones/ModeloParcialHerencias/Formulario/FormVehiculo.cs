using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formulario
{
    public partial class FormVehiculo : Form
    {
        //Tendria que crearle un atributo que contenga el vehiculo
        private Vehiculos miVehiculo; 
        public FormVehiculo()
        {
            InitializeComponent();
            //Esta linea hace que todos los enumerados de marca se pongan como opciones del combo
            this.cmbMarca.DataSource = Enum.GetValues(typeof(EMarcas));
        }
        //Lo hago protected y virtual porque los formularios de cada herencia van a tener el mismo
        //Metodo, entonces lo polimorfizo
        protected virtual void btnAceptar_Click(object sender, EventArgs e)
        {
            this.miVehiculo = new Vehiculos(this.txtPatente.Text, byte.Parse(this.txtCantRuedas.Text),
                                        (EMarcas)this.cmbMarca.SelectedItem);//casteo el item del combobox a EMarca
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
