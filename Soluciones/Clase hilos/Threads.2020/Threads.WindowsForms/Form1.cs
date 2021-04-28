using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads.WindowsForms
{
    public delegate void DelegadoThreadSinParam();

    public delegate void DelegadoThreadConParam(object param);

    public partial class Form1 : Form
    {
        protected Thread hilo;

        public Form1()
        {
            InitializeComponent();

            this.btnSinParams.Click += new EventHandler(this.ManejadorSinParams);
            this.btnConParams.Click += new EventHandler(this.ManejadorConParams);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void ManejadorSinParams(object s, EventArgs e)
        {
            this.hilo = new Thread(this.DoWork);

            this.hilo.Start();
        }
        private void ManejadorConParams(object s, EventArgs e)
        {
            this.hilo = new Thread(this.DoWorkParam);

            this.hilo.Start("Desde hilo, con parámetros");
        }

        public void DoWork()
        {
            //FALLA!!!
            //this.lblMensaje.Text = "Desde hilo";

            if (this.lblMensaje.InvokeRequired)
            {
                DelegadoThreadSinParam delegado = new DelegadoThreadSinParam(this.DoWork);

                //FALLA!!!
                //delegado.Invoke();

                //DESDE EL HILO PRINCIPAL, INVOCO AL DELEGADO
                this.Invoke(delegado);
            }
            else
            {
                this.lblMensaje.Text = "Desde hilo";
            }

        }

        public void DoWorkParam(object param)
        {

            if (this.lblMensaje.InvokeRequired)
            {
                DelegadoThreadConParam delegado = new DelegadoThreadConParam(this.DoWorkParam);

                //ARRAY DE OBJECT PARA EL PARAMETRO
                object[] parametro = new object[] { param };

                //DESDE EL HILO PRINCIPAL, INVOCO AL DELEGADO
                this.Invoke(delegado, parametro);
            }
            else
            {
                this.lblMensaje.Text = param.ToString();
            }

        }
    }
}
