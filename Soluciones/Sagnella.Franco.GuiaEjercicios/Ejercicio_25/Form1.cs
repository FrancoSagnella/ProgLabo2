using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ejercicio_22Clases;

namespace Ejercicio_25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BinarioDecimal_Click(object sender, EventArgs e)
        {
            this.textBox3.Text = Conversor.BinarioDecimal(this.textBox1.Text);
        }

        private void DecimalBinario_Click(object sender, EventArgs e)
        {
            this.textBox4.Text = Conversor.DecimalBinario(this.textBox2.Text);
        }
    }
}
