using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using EntidadesBD;

namespace _02_DataAdapter
{
    public partial class frmPrincipal : Form
    {
        private const String PATH_XML_PERSONAS = @"C:\archivos\DataTablePersonasDatos.xml";
        private const String PATH_XML_PERSONAS_SCHEMA = @"C:\archivos\DataTablePersonasSchema.xml";

        private DataTable dtPersona;

        #region Constructor

        public frmPrincipal()
        {
            InitializeComponent();

            this.dgvGrilla.MultiSelect = false;
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrilla.AllowUserToAddRows = false;
            this.dgvGrilla.AllowUserToDeleteRows = false;
            this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        private void btnCrearDataTable_Click(object sender, EventArgs e)
        {
            this.dtPersona = new DataTable("Persona");

            this.dtPersona.Columns.Add("id", typeof(int));
            this.dtPersona.Columns.Add("nombre", typeof(string));
            this.dtPersona.Columns.Add("apellido", typeof(string));
            this.dtPersona.Columns.Add("edad", typeof(int));

            this.dtPersona.PrimaryKey = new DataColumn[] { this.dtPersona.Columns[0] };

            this.dtPersona.Columns["id"].AutoIncrement = true;
            this.dtPersona.Columns["id"].AutoIncrementSeed = 1;//obtener el último id insertado en la tabla
            this.dtPersona.Columns["id"].AutoIncrementStep = 1;     

            MessageBox.Show("Se ha creado el DataTable!!!");

            this.dgvGrilla.DataSource = this.dtPersona;
        }

        private void btnCargarDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                if ( ! this.CargarDataTableConArrayObject())
                {
                    MessageBox.Show("Error al cargar DataTable. ", 
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCargarDataTableLista_Click(object sender, EventArgs e)
        {
            try
            {
                if ( ! this.CargarDataTableConListaProductos())
                {
                        MessageBox.Show("Error al cargar DataTable. ", 
                        "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnEsquema_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtPersona.WriteXmlSchema(PATH_XML_PERSONAS_SCHEMA);

                MessageBox.Show("Se ha serializado el esquema del DataTable!!!");
            }
            catch
            {
                MessageBox.Show("Error al serializar el esquema del DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            try
            {
                this.dtPersona.WriteXml(PATH_XML_PERSONAS);

                MessageBox.Show("Se han serializado los datos del DataTable!!!");
            }
            catch
            {
                MessageBox.Show("Error al serializar los datos del DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCargarEsquema_Click(object sender, EventArgs e)
        {
            if(File.Exists(PATH_XML_PERSONAS_SCHEMA))
            {
                this.dtPersona = new DataTable();

                this.dtPersona.ReadXmlSchema(PATH_XML_PERSONAS_SCHEMA);

                MessageBox.Show("Se ha cargado el esquema del DataTable!!!");
            }
            else
            {
                MessageBox.Show("No existe ningún documento XML");
            }
                
        }
        private void btnCargarXML_Click(object sender, EventArgs e)
        {
            if (File.Exists(PATH_XML_PERSONAS))
            {
                this.dtPersona.ReadXml(PATH_XML_PERSONAS);

                MessageBox.Show("Se han cargado los datos del DataTable!!!");

                this.dgvGrilla.DataSource = this.dtPersona;
            }
            else
            {
                MessageBox.Show("No existe ningún documento XML");
            }
               
        }

        private void btnMostrarRowState_Click(object sender, EventArgs e)
        {
            frmMostrar frm = new frmMostrar(this.dtPersona);

            frm.StartPosition = FormStartPosition.CenterScreen;

            frm.ShowDialog();
        }

        private void btnAceptarCambios_Click(object sender, EventArgs e)
        {
            this.dtPersona.AcceptChanges();

            //foreach (DataRow fila in this.dtProductos.Rows)
            //{
            //    fila.AcceptChanges();
            //}
        }

        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            this.dtPersona.RejectChanges();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            frmPersona frm = new frmPersona();

            try
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    DataRow fila = this.dtPersona.NewRow();

                    fila[1] = frm.Persona.Nombre;
                    fila["Apellido"] = frm.Persona.Apellido;
                    fila["Edad"] = frm.Persona.Edad;

                    this.dtPersona.Rows.Add(fila);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Int32 indice = this.dgvGrilla.CurrentRow.Index;

            Persona p = new Persona(int.Parse(this.dtPersona.Rows[indice][0].ToString()), 
                                    this.dtPersona.Rows[indice]["Apellido"].ToString(), 
                                    this.dtPersona.Rows[indice]["Nombre"].ToString(), 
                                    int.Parse(this.dtPersona.Rows[indice]["Edad"].ToString()));

            frmPersona frm = new frmPersona(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.dtPersona.Rows[indice]["Apellido"] = frm.Persona.Apellido;
                this.dtPersona.Rows[indice]["Nombre"] = frm.Persona.Nombre;
                this.dtPersona.Rows[indice][3] = frm.Persona.Edad;
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Int32 indice = this.dgvGrilla.CurrentRow.Index;

            Persona p = new Persona(int.Parse(this.dtPersona.Rows[indice][0].ToString()), 
                                    this.dtPersona.Rows[indice]["Apellido"].ToString(), 
                                    this.dtPersona.Rows[indice]["Nombre"].ToString(), 
                                    int.Parse(this.dtPersona.Rows[indice]["Edad"].ToString()));

            frmPersona frm = new frmPersona(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.dtPersona.Rows[indice].Delete();
            }
        }

        #region Métodos privados

        private Boolean CargarDataTableConArrayObject()
        {
            Boolean todoOK = false;

            try
            {
                //this.dtPersona.Rows.Add(new Object[] {"Mario", "Martinez", 66 });
                this.dtPersona.Rows.Add(new Object[] { 1, "Mario", "Martinez", 66 });
                this.dtPersona.Rows.Add(new Object[] { 2, "Jorge", "Brito", 22 });
                this.dtPersona.Rows.Add(new Object[] { 3, "Antonio", "Rosales", 16 });
                this.dtPersona.Rows.Add(new Object[] { 4, "Ana", "Ríos", 23 });

                todoOK = true;
            }
            catch (Exception)
            {
                todoOK = false;
            }

            return todoOK;
        }

        private Boolean CargarDataTableConListaProductos()
        {
            Boolean todoOK = false;

            try
            {
                DataRow fila;

                foreach (Persona p in CargarListaGenericaPersonas())
                {
                    fila = this.dtPersona.NewRow();

                    //fila[0] = p.ID;
                    fila["Nombre"] = p.Nombre;
                    fila["Apellido"] = p.Apellido;
                    fila[3] = p.Edad;

                    this.dtPersona.Rows.Add(fila);
                }

                todoOK = true;
            }
            catch (Exception)
            {
                todoOK = false;
            }

            return todoOK;
        }

        private List<Persona> CargarListaGenericaPersonas()
        {
            List<Persona> lista = new List<Persona>();

            lista.Add(new Persona(25, "Cecilia", "Enriquez", 33));
            lista.Add(new Persona(26, "Paolo", "Carterin", 54));
            lista.Add(new Persona(27, "José", "Arias", 45));

            return lista;
        }

        #endregion

    }
}
