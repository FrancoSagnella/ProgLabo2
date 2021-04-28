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
    public partial class FormLavadero : Form
    {
        //El form tiene un atributo de instancia que contiene al lavadero
        private Lavadero miLavadero;

        public Lavadero MiLavadero//Hago una propiedad para retornar el lavadero que tiene el form
        {
            get
            {
                return this.miLavadero;
            }
        }
        public FormLavadero()
        {
            InitializeComponent();
            //Cuando se crea el form, creo un lavadero
            this.miLavadero = new Lavadero(100, 500, 200);
            this.Mostrar();
        }

        private void comboBoxOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Creo una variable tipo comparison para poder hacer el ordenamiento
            Comparison<Vehiculos> comparador = null;

            switch (this.comboBoxOrden.SelectedIndex)
            {
                //en la variable comparador guardo la funcion con el criterio de ordenamiento
                case 0:
                    comparador = Lavadero.OrdenarVehiculosPorPatente;
                    break;
                case 1:
                    comparador = this.MiLavadero.OrdenarVehiculosPorMarca;
                    break;
            }
            //milavadero tiene adentro una lista de vehiculos
            //uso la funcion sort de la lista, a esta le tengo que pasar la funcion de criterio
            //que para eso la guarde en comparador dependiendo de que indice del combobox estaba
            this.MiLavadero.Vehiculos.Sort(comparador);

            //Despues de ordenarla, vuelvo a mostrar
            this.Mostrar();
        }

        private void btnMoto_Click(object sender, EventArgs e)
        {
            //Tendria que crear un objeto de tipo formulario de moto
            //para abrirlo y poder cargar los datos
            FormMoto frm = new FormMoto();
            //ShowDialog abre el formulario y devuelve el dialog result
            //si es ok, es porque se toco el boton ok
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //Accedo al listado de vehiculos, y agrego la moto que cree
                //La moto que cree la traigo desde la propiedad get que cree en el formMoto
                this.miLavadero += frm.MiMoto;
                //Lo muestro, asi se actualiza
                this.Mostrar();
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            FormAuto frm = new FormAuto();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Accedo al listado de vehiculos, y agrego la moto que cree
                //La moto que cree la traigo desde la propiedad get que cree en el formMoto
                this.miLavadero += frm.MiAuto;
                //Lo muestro, asi se actualiza
                this.Mostrar();
            }
        }

        private void btnCamion_Click(object sender, EventArgs e)
        {
            FormCamion frm = new FormCamion();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //Accedo al listado de vehiculos, y agrego la moto que cree
                //La moto que cree la traigo desde la propiedad get que cree en el formMoto
                this.miLavadero += frm.MiCamion;
                //Lo muestro, asi se actualiza
                this.Mostrar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = this.listBox1.SelectedIndex;

            if (i > 0)
            {
                this.miLavadero -= this.miLavadero.Vehiculos[i];
                this.Mostrar();
            }
        }

        private void Mostrar()
        {
            //Con esto limpio los elementos que estan en el listbox
            this.listBox1.Items.Clear();

            //Tengo que pasarle al listbox el string con la informacion de los vehiculos
            this.listBox1.Items.Add(this.MiLavadero.GetLavadero);
            foreach(Vehiculos item in this.miLavadero.Vehiculos)
            {
                this.listBox1.Items.Add(item.Mostrar());
            }
        }
    }
}
