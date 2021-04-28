namespace _02_DataAdapter
{
    partial class frmMostrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvVisor = new System.Windows.Forms.DataGridView();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVisor
            // 
            this.dgvVisor.AllowUserToAddRows = false;
            this.dgvVisor.AllowUserToDeleteRows = false;
            this.dgvVisor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Estado});
            this.dgvVisor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVisor.Location = new System.Drawing.Point(0, 0);
            this.dgvVisor.Name = "dgvVisor";
            this.dgvVisor.ReadOnly = true;
            this.dgvVisor.Size = new System.Drawing.Size(257, 381);
            this.dgvVisor.TabIndex = 2;
            // 
            // Estado
            // 
            this.Estado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Estado.HeaderText = "Estado de la fila";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // frmMostrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 381);
            this.Controls.Add(this.dgvVisor);
            this.Name = "frmMostrar";
            this.Text = "frmMostrar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvVisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}