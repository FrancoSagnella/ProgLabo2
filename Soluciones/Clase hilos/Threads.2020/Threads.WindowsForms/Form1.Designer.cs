namespace Threads.WindowsForms
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnSinParams = new System.Windows.Forms.Button();
            this.btnConParams = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.Location = new System.Drawing.Point(12, 36);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(233, 21);
            this.lblMensaje.TabIndex = 0;
            this.lblMensaje.Text = "lblMensaje";
            // 
            // btnSinParams
            // 
            this.btnSinParams.Location = new System.Drawing.Point(15, 94);
            this.btnSinParams.Name = "btnSinParams";
            this.btnSinParams.Size = new System.Drawing.Size(107, 23);
            this.btnSinParams.TabIndex = 1;
            this.btnSinParams.Text = "Hilo sin parámetros";
            this.btnSinParams.UseVisualStyleBackColor = true;
            // 
            // btnConParams
            // 
            this.btnConParams.Location = new System.Drawing.Point(128, 94);
            this.btnConParams.Name = "btnConParams";
            this.btnConParams.Size = new System.Drawing.Size(117, 23);
            this.btnConParams.TabIndex = 2;
            this.btnConParams.Text = "Hilo con parámetros";
            this.btnConParams.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 131);
            this.Controls.Add(this.btnConParams);
            this.Controls.Add(this.btnSinParams);
            this.Controls.Add(this.lblMensaje);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.Button btnSinParams;
        private System.Windows.Forms.Button btnConParams;
    }
}

