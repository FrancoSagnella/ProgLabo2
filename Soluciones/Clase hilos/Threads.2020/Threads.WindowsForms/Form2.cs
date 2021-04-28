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
    public partial class Form2 : Form
    {
        protected Thread hilo;



        public Form2()
        {
            InitializeComponent();

            DelegadoThreadConParam delegado = new DelegadoThreadConParam(DoWork);

            this.hilo = new Thread(this.DoWork);

            this.imgImagen.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + @"\img\bernabeu.jpg";

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.hilo.Start();
        }

        private void DoWork(object param)
        {

            if (this.imgImagen.InvokeRequired)
            {
                bool continua = true;
                int highLights = 0;
                string resultado = "";

                DelegadoThreadConParam delegado = new DelegadoThreadConParam(this.DoWork);

                object[] imagen = new object[6];

                imagen[0] = AppDomain.CurrentDomain.BaseDirectory + @"\img\pipa.jpg";
                imagen[1] = AppDomain.CurrentDomain.BaseDirectory + @"\img\oso_pratto.jpg";
                imagen[2] = AppDomain.CurrentDomain.BaseDirectory + @"\img\juanfer.jpg";
                imagen[3] = AppDomain.CurrentDomain.BaseDirectory + @"\img\pity.jpg";
                imagen[4] = AppDomain.CurrentDomain.BaseDirectory + @"\img\muñeco.jpg";
                imagen[5] = AppDomain.CurrentDomain.BaseDirectory + @"\img\river_campeon.jpg";

                do
                {
                    switch (highLights)
                    {
                        case 0: resultado = "0 - 1";
                            break;
                        case 1:
                            resultado = "1 - 1";
                            break;
                        case 2:
                            resultado = "2 - 1";
                            break;
                        case 3:
                            resultado = "3 - 1";
                            break;
                        default:
                            resultado = "RIVER CAMPEON!!!";
                            break;
                    }

                    //ARRAY DE OBJECT PARA EL PARAMETRO
                    object[] parametro = new object[] { imagen[highLights], resultado };

                    highLights++;

                    //DESDE EL HILO PRINCIPAL, INVOCO AL DELEGADO
                    this.Invoke(delegado, (object)parametro);

                    if (highLights == 6)
                    {
                        continua = false;
                    }

                    Thread.Sleep(3000);

                } while (continua);


            }
            else
            {
                this.imgImagen.ImageLocation = ((object[])param)[0].ToString();
                this.lblResultado.Text = ((object[])param)[1].ToString();
            }

        }

    }
}
