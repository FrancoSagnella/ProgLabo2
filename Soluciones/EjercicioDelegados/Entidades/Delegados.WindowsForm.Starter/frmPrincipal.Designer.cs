namespace Delegados.WindowsForm.Starter
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
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AltaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestDelegadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MostarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AltaToolStripMenuItem,
            this.MostarToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(342, 24);
            this.MenuStrip1.TabIndex = 1;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // AltaToolStripMenuItem
            // 
            this.AltaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestDelegadosToolStripMenuItem,
            this.alumnosToolStripMenuItem});
            this.AltaToolStripMenuItem.Name = "AltaToolStripMenuItem";
            this.AltaToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.AltaToolStripMenuItem.Text = "&Alta";
            // 
            // TestDelegadosToolStripMenuItem
            // 
            this.TestDelegadosToolStripMenuItem.Name = "TestDelegadosToolStripMenuItem";
            this.TestDelegadosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.TestDelegadosToolStripMenuItem.Text = "Test Delegados";
            this.TestDelegadosToolStripMenuItem.Click += new System.EventHandler(this.TestDelegadosToolStripMenuItem_Click);
            // 
            // MostarToolStripMenuItem
            // 
            this.MostarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestToolStripMenuItem});
            this.MostarToolStripMenuItem.Name = "MostarToolStripMenuItem";
            this.MostarToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.MostarToolStripMenuItem.Text = "&Mostar";
            // 
            // TestToolStripMenuItem
            // 
            this.TestToolStripMenuItem.Name = "TestToolStripMenuItem";
            this.TestToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.TestToolStripMenuItem.Text = "Test";
            this.TestToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            this.alumnosToolStripMenuItem.Click += new System.EventHandler(this.alumnosToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 262);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem AltaToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TestDelegadosToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem MostarToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
    }
}

