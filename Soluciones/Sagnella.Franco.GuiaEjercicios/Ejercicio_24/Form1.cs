using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio_21Clases;

namespace Ejercicio_24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fahrenheit f = double.Parse(this.txtFahrenheit.Text);

            this.txtFahrenheitAFahrenheit.Text = f.GetCantidad.ToString();

            Celcius c = (Celcius)f;
            this.txtFahrenheitACelcius.Text = c.GetCantidad.ToString();

            Kelvin k = (Kelvin)f;
            this.txtFahrenheitAKelvin.Text = k.GetCantidad.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Celcius f = double.Parse(this.txtFahrenheit.Text);
            
            this.txtCelciusACelcius.Text = f.GetCantidad.ToString();

            Fahrenheit c = (Fahrenheit)f;
            this.txtCelciusAFahrenheit.Text = c.GetCantidad.ToString();

            Kelvin k = (Kelvin)f;
            this.txtCelciusAKelvin.Text = k.GetCantidad.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Kelvin f = double.Parse(this.txtFahrenheit.Text);

            this.txtKelvinAKelvin.Text = f.GetCantidad.ToString();

            Fahrenheit c = (Fahrenheit)f;
            this.txtKelvinACelcius.Text = c.GetCantidad.ToString();

            Celcius k = (Celcius)f;
            this.txtKelvinAKelvin.Text = k.GetCantidad.ToString();
        }
    }
}
