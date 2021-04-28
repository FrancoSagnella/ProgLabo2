using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using EntidadesBD;

namespace _02_DataAdapter
{
    public partial class FrmPrincipal : Form
    {
        private const String PATH_XML_PERSONAS = @"C:\archivos\DataTablePersonasDatos.xml";
        private const String PATH_XML_PERSONAS_SCHEMA = @"C:\archivos\DataTablePersonasSchema.xml";

        protected SqlDataAdapter da;
        protected DataTable dt;

        #region Constructor

        public FrmPrincipal()
        {
            InitializeComponent();

            if (!this.ConfigurarDataAdapter())
            {
                MessageBox.Show("ERROR AL CONFIGURAR EL DATAADAPTER!!!");
                this.Close();
            }

            this.ConfigurarDataTable();

            try
            {
                this.da.Fill(this.dt);

                this.ConfigurarGrilla();

                this.dgvGrilla.DataSource = this.dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region DataAdapter

        private bool ConfigurarDataAdapter()
        {
            bool rta = false;

            try
            {
                SqlConnection cn = new SqlConnection(Properties.Settings.Default.Conexion);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT id, nombre, apellido, edad FROM PERSONAS", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO PERSONAS (nombre, apellido, edad) VALUES (@nombre, @apellido, @edad)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE PERSONAS SET nombre=@nombre, apellido=@apellido, edad=@edad WHERE id=@id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM PERSONAS WHERE id=@id", cn);

                this.da.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.InsertCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
                this.da.InsertCommand.Parameters.Add("@edad", SqlDbType.Int, 10, "edad");

                this.da.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
                this.da.UpdateCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
                this.da.UpdateCommand.Parameters.Add("@edad", SqlDbType.Int, 10, "edad");
                this.da.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                this.da.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 10, "id");

                rta = true;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            return rta;
        }

        #endregion

        #region DataTable

        private void ConfigurarDataTable()
        {
            this.dt = new DataTable("Persona");

            this.dt.Columns.Add("id", typeof(int));
            this.dt.Columns.Add("nombre", typeof(string));
            this.dt.Columns.Add("apellido", typeof(string));
            this.dt.Columns.Add("edad", typeof(int));

            this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

            this.dt.Columns["id"].AutoIncrement = true;
            this.dt.Columns["id"].AutoIncrementSeed = 1;//obtener el último id insertado en la tabla
            this.dt.Columns["id"].AutoIncrementStep = 1;
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

        #region Manejores de eventos

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.da.Update(this.dt);

                MessageBox.Show("Sincronizado!!!");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            FrmPersona frm = new FrmPersona();
            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow fila = this.dt.NewRow();

                //fila["id"] = frm.Persona.Id;
                fila["nombre"] = frm.Persona.Nombre;
                fila["apellido"] = frm.Persona.Apellido;
                fila["edad"] = frm.Persona.Edad;

                this.dt.Rows.Add(fila);
            }

        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;

            DataRow fila = this.dt.Rows[i];

            int id = int.Parse(fila["id"].ToString());
            string nombre = fila["nombre"].ToString();
            string apellido = fila["apellido"].ToString();
            int edad = int.Parse(fila["edad"].ToString());

            Persona p = new Persona(id, nombre, apellido, edad);

            FrmPersona frm = new FrmPersona(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                fila["nombre"] = frm.Persona.Nombre;
                fila["apellido"] = frm.Persona.Apellido;
                fila["edad"] = frm.Persona.Edad;
            }

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            int i = this.dgvGrilla.SelectedRows[0].Index;

            DataRow fila = this.dt.Rows[i];

            int id = int.Parse(fila["id"].ToString());
            string nombre = fila["nombre"].ToString();
            string apellido = fila["apellido"].ToString();
            int edad = int.Parse(fila["edad"].ToString());

            Persona p = new Persona(id, nombre, apellido, edad);

            FrmPersona frm = new FrmPersona(p);

            frm.StartPosition = FormStartPosition.CenterScreen;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                fila.Delete();
            }

        }
        private void btnCargarDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(PATH_XML_PERSONAS_SCHEMA))
                {
                    this.dt = new DataTable();

                    this.dt.ReadXmlSchema(PATH_XML_PERSONAS_SCHEMA);

                    MessageBox.Show("Se ha cargado el esquema del DataTable!!!");
                }
                else
                {
                    MessageBox.Show("No existe ningún documento XML");
                }
                    

                if (File.Exists(PATH_XML_PERSONAS))
                {
                    this.dt.ReadXml(PATH_XML_PERSONAS);

                    MessageBox.Show("Se han cargado los datos del DataTable!!!");

                }
                else
                {
                    MessageBox.Show("No existe ningún documento XML");
                }

                this.dgvGrilla.DataSource = this.dt;
            }
            catch
            {
                MessageBox.Show("Error al cargar el DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGuardarDataTable_Click(object sender, EventArgs e)
        {
            try
            {
                this.dt.WriteXmlSchema(PATH_XML_PERSONAS_SCHEMA);

                this.dt.WriteXml(PATH_XML_PERSONAS);

                MessageBox.Show("Se han guardado el esquema y los datos del DataTable!!!");

            }
            catch
            {
                MessageBox.Show("Error al guardar el DataTable. ",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
