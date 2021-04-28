using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesBD;

namespace WindowsFormsBD
{
    public partial class frmPersonas : Form
    {
        #region Atributos

        private List<Persona> personas;
        private DataTable tabla;
        private AccesoDatos objAcceso;

        #endregion

        #region Constructor
        public frmPersonas()
        {
            InitializeComponent();

            this.objAcceso = new AccesoDatos();
            this.personas = this.objAcceso.ObtenerListaPersonas();
            this.tabla = this.objAcceso.ObtenerTablaPersonas();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Métodos

        #region Carga del Form
        private void frmPersonas_Load(object sender, EventArgs e)
        {
            this.ConfigurarGrilla();

            #region Uso DataTable

            this.dgvGrilla.DataSource = this.tabla;

            #endregion

            #region Uso List<Persona>

            //this.dgvGrilla.DataSource = this.personas;

            #endregion
        }

        #endregion

        #region Alta
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ABM frm = new ABM();

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!this.objAcceso.InsertarPersona(frm.PersonaDelFormulario))
                {
                    MessageBox.Show("ERROR", "Error al INSERTAR la persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region Uso DataTable

                DataRow fila = this.tabla.NewRow();

                fila["apellido"] = frm.PersonaDelFormulario.Apellido;
                fila["nombre"] = frm.PersonaDelFormulario.Nombre;
                fila["edad"] = frm.PersonaDelFormulario.Edad;

                this.tabla.Rows.Add(fila);
                this.tabla.AcceptChanges();

                #endregion

                #region Uso List<Persona>

                //this.personas = this.objAcceso.ObtenerListaPersonas();
                //this.dgvGrilla.DataSource = this.personas;

                #endregion

            }
        }
        #endregion

        #region Baja
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;

            #region Uso DataTable

            DataRow fila = this.tabla.Rows[i];

            Persona p = new Persona(int.Parse(fila[0].ToString()), fila["apellido"].ToString(),
                                    fila["nombre"].ToString(), int.Parse(fila[3].ToString()));

            #endregion

            #region Uso List<Persona>

            //Persona p = this.personas[i];

            #endregion

            ABM frm = new ABM(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!this.objAcceso.EliminarPersona(p))
                {
                    MessageBox.Show("ERROR", "Error al ELIMINAR a la persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region Uso DataTable

                this.tabla.Rows[i].Delete();
                this.tabla.AcceptChanges();

                #endregion

                #region Uso List<Persona>

                //this.personas = this.objAcceso.ObtenerListaPersonas();
                //this.dgvGrilla.DataSource = this.personas;

                #endregion

            }

        }

        #endregion

        #region Modificación
        private void btnModificar_Click(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;

            #region Uso DataTable

            DataRow fila = this.tabla.Rows[i];

            Persona p = new Persona(int.Parse(fila[0].ToString()), fila["apellido"].ToString(),
                                    fila["nombre"].ToString(), int.Parse(fila[3].ToString()));

            #endregion

            #region Uso List<Persona>

            //Persona p = this.personas[i];

            #endregion

            ABM frm = new ABM(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (!this.objAcceso.ModificarPersona(frm.PersonaDelFormulario))
                {
                    MessageBox.Show("ERROR", "Error al MODIFICAR a la persona", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                #region Uso DataTable

                this.tabla.Rows[i]["apellido"] = frm.PersonaDelFormulario.Apellido;
                this.tabla.Rows[i]["nombre"] = frm.PersonaDelFormulario.Nombre;
                this.tabla.Rows[i]["edad"] = frm.PersonaDelFormulario.Edad;

                this.tabla.AcceptChanges();

                #endregion

                #region Uso List<Persona>

                //this.personas = this.objAcceso.ObtenerListaPersonas();
                //this.dgvGrilla.DataSource = this.personas;

                #endregion

            }
        }

        #endregion

        #region Cierre
        private void frmPersonas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de SALIR?", "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region DataGridView

        private void ConfigurarGrilla()
        {
            // Coloco color de fondo para las filas
            this.dgvGrilla.RowsDefaultCellStyle.BackColor = Color.Wheat;

            // Alterno colores
            this.dgvGrilla.AlternatingRowsDefaultCellStyle.BackColor = Color.BurlyWood;

            // Pongo color de fondo a la grilla
            this.dgvGrilla.BackgroundColor = Color.Beige;

            // Defino fuente para el encabezado y alineación del encabezado
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrilla.Font, FontStyle.Bold);
            this.dgvGrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Defino el color de las lineas de separación
            this.dgvGrilla.GridColor = Color.HotPink;

            // La grilla será de sólo lectura
            this.dgvGrilla.ReadOnly = false;

            // No permito la multiselección
            this.dgvGrilla.MultiSelect = false;

            // Selecciono toda la fila a la vez
            this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Hago que las columnas ocupen todo el ancho del 'DataGrid'
            this.dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Indico el color de la fila seleccionada
            this.dgvGrilla.RowsDefaultCellStyle.SelectionBackColor = Color.DarkOliveGreen;
            this.dgvGrilla.RowsDefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            // No permito modificar desde la grilla
            this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Saco los encabezados de las filas
            this.dgvGrilla.RowHeadersVisible = false;

        }

        #endregion

        #endregion

    }
}
