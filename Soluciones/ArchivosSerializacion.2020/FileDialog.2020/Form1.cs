using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileDialog._2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Title = "Guardar archivo";
            this.saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.saveFileDialog1.Filter = "TXT files|*.txt"; 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.CheckPathExists = true;
            this.saveFileDialog1.CheckFileExists = false;

            DialogResult rta = this.saveFileDialog1.ShowDialog();

            if (rta == DialogResult.OK)
            {
                MessageBox.Show(this.saveFileDialog1.FileName);

                string ruta = this.saveFileDialog1.FileName;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(ruta);

                sw.WriteLine(this.richTextBox1.Text);

                sw.Close();

                this.richTextBox1.Clear();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Title = "Abrir archivo";
            this.openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            this.openFileDialog1.Filter = "TXT files|*.txt";
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.CheckPathExists = true;
            this.openFileDialog1.FileName = "miArchivo";

            DialogResult rta = this.openFileDialog1.ShowDialog();


            if (rta == DialogResult.OK)
            {
                MessageBox.Show(this.openFileDialog1.FileName);

                System.IO.Stream lector = this.openFileDialog1.OpenFile();

                System.IO.StreamReader sr = new System.IO.StreamReader(lector);

                this.richTextBox1.Text = sr.ReadToEnd();

                sr.Close();
            }

        }
    }
}
