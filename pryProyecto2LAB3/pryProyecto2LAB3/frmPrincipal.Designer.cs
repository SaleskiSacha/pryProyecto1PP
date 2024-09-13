namespace pryProyecto2LAB3
{
    partial class frmPrincipal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.contactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarContactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarContactosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarOModificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barraDeEstado = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioTS = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.barraDeEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(336, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // contactosToolStripMenuItem
            // 
            this.contactosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listarContactosToolStripMenuItem,
            this.agregarContactosToolStripMenuItem,
            this.eliminarOModificarToolStripMenuItem});
            this.contactosToolStripMenuItem.Name = "contactosToolStripMenuItem";
            this.contactosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.contactosToolStripMenuItem.Text = "Contactos";
            this.contactosToolStripMenuItem.Click += new System.EventHandler(this.contactosToolStripMenuItem_Click);
            // 
            // listarContactosToolStripMenuItem
            // 
            this.listarContactosToolStripMenuItem.Name = "listarContactosToolStripMenuItem";
            this.listarContactosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.listarContactosToolStripMenuItem.Text = "Listar y Agregar Contactos";
            this.listarContactosToolStripMenuItem.Click += new System.EventHandler(this.listarContactosToolStripMenuItem_Click);
            // 
            // agregarContactosToolStripMenuItem
            // 
            this.agregarContactosToolStripMenuItem.Name = "agregarContactosToolStripMenuItem";
            this.agregarContactosToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.agregarContactosToolStripMenuItem.Text = "Exportar";
            this.agregarContactosToolStripMenuItem.Click += new System.EventHandler(this.agregarContactosToolStripMenuItem_Click);
            // 
            // eliminarOModificarToolStripMenuItem
            // 
            this.eliminarOModificarToolStripMenuItem.Name = "eliminarOModificarToolStripMenuItem";
            this.eliminarOModificarToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.eliminarOModificarToolStripMenuItem.Text = "Eliminar o Modificar";
            this.eliminarOModificarToolStripMenuItem.Click += new System.EventHandler(this.eliminarOModificarToolStripMenuItem_Click);
            // 
            // barraDeEstado
            // 
            this.barraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblUsuarioTS});
            this.barraDeEstado.Location = new System.Drawing.Point(0, 287);
            this.barraDeEstado.Name = "barraDeEstado";
            this.barraDeEstado.Size = new System.Drawing.Size(336, 22);
            this.barraDeEstado.TabIndex = 17;
            this.barraDeEstado.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(28, 17);
            this.lblStatus.Text = "BD: ";
            // 
            // lblUsuarioTS
            // 
            this.lblUsuarioTS.Name = "lblUsuarioTS";
            this.lblUsuarioTS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUsuarioTS.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pryProyecto2LAB3.Properties.Resources.Contacto;
            this.pictureBox1.Location = new System.Drawing.Point(0, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(336, 257);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 309);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.barraDeEstado);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmPrincipal";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.barraDeEstado.ResumeLayout(false);
            this.barraDeEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem contactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarContactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarContactosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarOModificarToolStripMenuItem;
        private System.Windows.Forms.StatusStrip barraDeEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioTS;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

