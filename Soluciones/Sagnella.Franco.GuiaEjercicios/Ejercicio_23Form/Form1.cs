using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monedas;

namespace Ejercicio_23Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLockCotizacion_Click(object sender, EventArgs e)
        {
            if(this.btnLockCotizacion.ImageIndex == 1)
            {
                this.txtCotizacionDolar.Enabled = false;
                this.txtCotizacionEuro.Enabled = false;
                this.txtCotizacionPeso.Enabled = false;
                this.btnLockCotizacion.ImageIndex = 0;
            }
            else
            {
                this.txtCotizacionDolar.Enabled = true;
                this.txtCotizacionEuro.Enabled = true;
                this.txtCotizacionPeso.Enabled = true;
                this.btnLockCotizacion.ImageIndex = 1;
            }
        }

        private void txtCotizacionEuro_Leave(object sender, EventArgs e)
        {
            Euro eu = new Euro(0, double.Parse(this.txtCotizacionEuro.Text));
        }

        private void txtCotizacionDolar_Leave(object sender, EventArgs e)
        {
            Dolar d = new Dolar(0, double.Parse(this.txtCotizacionDolar.Text));
        }

        private void txtCotizacionPeso_Leave(object sender, EventArgs e)
        {
            Pesos p = new Pesos(0, double.Parse(this.txtCotizacionPeso.Text));
        }

        private void btnConvertEuro_Click(object sender, EventArgs e)
        {
            Euro eu = double.Parse(this.txtEuro.Text);

            this.txtEuroAEruo.Text = eu.GetCantidad.ToString();

            Dolar d = (Dolar)eu;
            this.txtEuroADolar.Text = d.GetCantidad.ToString();

            Pesos p = (Pesos)eu;
            this.txtEuroAPesos.Text = p.GetCantidad.ToString();

        }

        private void btnConvertDolar_Click(object sender, EventArgs e)
        {
            Dolar d = double.Parse(this.txtDolar.Text);

            this.txtDoalrADolar.Text = d.GetCantidad.ToString();

            Euro eu = (Euro)d;
            this.txtDolarAEuro.Text = eu.GetCantidad.ToString();

            Pesos p = (Pesos)d;
            this.txtDolarAPesos.Text = p.GetCantidad.ToString();
        }

        private void btnConvertPesos_Click(object sender, EventArgs e)
        {
            Pesos p = double.Parse(this.txtPesos.Text);

            this.txtPesosAPesos.Text = p.GetCantidad.ToString();

            Dolar d = (Dolar)p;
            this.txtPesosADolar.Text = d.GetCantidad.ToString();

            Euro eu = (Euro)p;
            this.txtPesosAEuro.Text = eu.GetCantidad.ToString();
        }
    }
}
