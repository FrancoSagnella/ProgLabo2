namespace _02_DataAdapter
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAceptarCambios = new System.Windows.Forms.Button();
            this.btnCargarEsquema = new System.Windows.Forms.Button();
            this.btnMostrarRowState = new System.Windows.Forms.Button();
            this.btnCargarXML = new System.Windows.Forms.Button();
            this.btnDatos = new System.Windows.Forms.Button();
            this.btnEsquema = new System.Windows.Forms.Button();
            this.btnCargarDataTableLista = new System.Windows.Forms.Button();
            this.btnCargarDataTable = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.btnCrearDataTable = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnDeshacer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnBorrar.Location = new System.Drawing.Point(354, 26);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(160, 22);
            this.btnBorrar.TabIndex = 23;
            this.btnBorrar.Text = "Borrar Filas";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModificar.Location = new System.Drawing.Point(183, 26);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(160, 22);
            this.btnModificar.TabIndex = 22;
            this.btnModificar.Text = "Modificar Filas";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAceptarCambios
            // 
            this.btnAceptarCambios.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAceptarCambios.Location = new System.Drawing.Point(362, 331);
            this.btnAceptarCambios.Name = "btnAceptarCambios";
            this.btnAceptarCambios.Size = new System.Drawing.Size(175, 24);
            this.btnAceptarCambios.TabIndex = 21;
            this.btnAceptarCambios.Text = "&Aceptar Cambios";
            this.btnAceptarCambios.UseVisualStyleBackColor = true;
            this.btnAceptarCambios.Click += new System.EventHandler(this.btnAceptarCambios_Click);
            // 
            // btnCargarEsquema
            // 
            this.btnCargarEsquema.Location = new System.Drawing.Point(386, 12);
            this.btnCargarEsquema.Name = "btnCargarEsquema";
            this.btnCargarEsquema.Size = new System.Drawing.Size(151, 23);
            this.btnCargarEsquema.TabIndex = 20;
            this.btnCargarEsquema.Text = "Cargar Esquema con XML";
            this.btnCargarEsquema.UseVisualStyleBackColor = true;
            this.btnCargarEsquema.Click += new System.EventHandler(this.btnCargarEsquema_Click);
            // 
            // btnMostrarRowState
            // 
            this.btnMostrarRowState.Location = new System.Drawing.Point(362, 362);
            this.btnMostrarRowState.Name = "btnMostrarRowState";
            this.btnMostrarRowState.Size = new System.Drawing.Size(175, 23);
            this.btnMostrarRowState.TabIndex = 19;
            this.btnMostrarRowState.Text = "Mostrar RowState";
            this.btnMostrarRowState.UseVisualStyleBackColor = true;
            this.btnMostrarRowState.Click += new System.EventHandler(this.btnMostrarRowState_Click);
            // 
            // btnCargarXML
            // 
            this.btnCargarXML.Location = new System.Drawing.Point(386, 41);
            this.btnCargarXML.Name = "btnCargarXML";
            this.btnCargarXML.Size = new System.Drawing.Size(151, 23);
            this.btnCargarXML.TabIndex = 18;
            this.btnCargarXML.Text = "Cargar DataTable con XML";
            this.btnCargarXML.UseVisualStyleBackColor = true;
            this.btnCargarXML.Click += new System.EventHandler(this.btnCargarXML_Click);
            // 
            // btnDatos
            // 
            this.btnDatos.Location = new System.Drawing.Point(188, 41);
            this.btnDatos.Name = "btnDatos";
            this.btnDatos.Size = new System.Drawing.Size(175, 23);
            this.btnDatos.TabIndex = 17;
            this.btnDatos.Text = "Serializar Datos DataTable";
            this.btnDatos.UseVisualStyleBackColor = true;
            this.btnDatos.Click += new System.EventHandler(this.btnDatos_Click);
            // 
            // btnEsquema
            // 
            this.btnEsquema.Location = new System.Drawing.Point(188, 12);
            this.btnEsquema.Name = "btnEsquema";
            this.btnEsquema.Size = new System.Drawing.Size(175, 23);
            this.btnEsquema.TabIndex = 16;
            this.btnEsquema.Text = "Serializar Esquema DataTable";
            this.btnEsquema.UseVisualStyleBackColor = true;
            this.btnEsquema.Click += new System.EventHandler(this.btnEsquema_Click);
            // 
            // btnCargarDataTableLista
            // 
            this.btnCargarDataTableLista.Location = new System.Drawing.Point(15, 361);
            this.btnCargarDataTableLista.Name = "btnCargarDataTableLista";
            this.btnCargarDataTableLista.Size = new System.Drawing.Size(153, 23);
            this.btnCargarDataTableLista.TabIndex = 15;
            this.btnCargarDataTableLista.Text = "Cargar DataTable con Lista\r\n";
            this.btnCargarDataTableLista.UseVisualStyleBackColor = true;
            this.btnCargarDataTableLista.Click += new System.EventHandler(this.btnCargarDataTableLista_Click);
            // 
            // btnCargarDataTable
            // 
            this.btnCargarDataTable.Location = new System.Drawing.Point(15, 332);
            this.btnCargarDataTable.Name = "btnCargarDataTable";
            this.btnCargarDataTable.Size = new System.Drawing.Size(153, 23);
            this.btnCargarDataTable.TabIndex = 14;
            this.btnCargarDataTable.Text = "Cargar DataTable con Array";
            this.btnCargarDataTable.UseVisualStyleBackColor = true;
            this.btnCargarDataTable.Click += new System.EventHandler(this.btnCargarDataTable_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(15, 70);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(524, 244);
            this.dgvGrilla.TabIndex = 13;
            // 
            // btnCrearDataTable
            // 
            this.btnCrearDataTable.Location = new System.Drawing.Point(13, 12);
            this.btnCrearDataTable.Name = "btnCrearDataTable";
            this.btnCrearDataTable.Size = new System.Drawing.Size(153, 23);
            this.btnCrearDataTable.TabIndex = 12;
            this.btnCrearDataTable.Text = "&Crear DataTable";
            this.btnCrearDataTable.UseVisualStyleBackColor = true;
            this.btnCrearDataTable.Click += new System.EventHandler(this.btnCrearDataTable_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.btnAlta);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Location = new System.Drawing.Point(15, 392);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 61);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABM con formulario";
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(8, 26);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(160, 22);
            this.btnAlta.TabIndex = 24;
            this.btnAlta.Text = "Cargar Data Table con Forms";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.Location = new System.Drawing.Point(189, 347);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(149, 23);
            this.btnDeshacer.TabIndex = 25;
            this.btnDeshacer.Text = "&Deshacer Cambios";
            this.btnDeshacer.UseVisualStyleBackColor = true;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 472);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAceptarCambios);
            this.Controls.Add(this.btnCargarEsquema);
            this.Controls.Add(this.btnMostrarRowState);
            this.Controls.Add(this.btnCargarXML);
            this.Controls.Add(this.btnDatos);
            this.Controls.Add(this.btnEsquema);
            this.Controls.Add(this.btnCargarDataTableLista);
            this.Controls.Add(this.btnCargarDataTable);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.btnCrearDataTable);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnBorrar;
        internal System.Windows.Forms.Button btnModificar;
        internal System.Windows.Forms.Button btnAceptarCambios;
        internal System.Windows.Forms.Button btnCargarEsquema;
        internal System.Windows.Forms.Button btnMostrarRowState;
        internal System.Windows.Forms.Button btnCargarXML;
        internal System.Windows.Forms.Button btnDatos;
        internal System.Windows.Forms.Button btnEsquema;
        internal System.Windows.Forms.Button btnCargarDataTableLista;
        internal System.Windows.Forms.Button btnCargarDataTable;
        internal System.Windows.Forms.DataGridView dgvGrilla;
        internal System.Windows.Forms.Button btnCrearDataTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnDeshacer;
    }
}

