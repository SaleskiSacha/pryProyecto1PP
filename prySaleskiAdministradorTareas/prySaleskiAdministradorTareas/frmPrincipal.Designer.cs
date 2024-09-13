namespace prySaleskiAdministradorTareas
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeTareasYPrioridadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminacionDeTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeTareasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.barraDeEstado = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioTS = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.barraDeEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tareasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(373, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tareasToolStripMenuItem
            // 
            this.tareasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadoDeTareasYPrioridadesToolStripMenuItem,
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem,
            this.eliminacionDeTareasToolStripMenuItem,
            this.reporteDeTareasToolStripMenuItem});
            this.tareasToolStripMenuItem.Name = "tareasToolStripMenuItem";
            this.tareasToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tareasToolStripMenuItem.Text = "Tareas";
            // 
            // listadoDeTareasYPrioridadesToolStripMenuItem
            // 
            this.listadoDeTareasYPrioridadesToolStripMenuItem.Name = "listadoDeTareasYPrioridadesToolStripMenuItem";
            this.listadoDeTareasYPrioridadesToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.listadoDeTareasYPrioridadesToolStripMenuItem.Text = "Listado de tareas y prioridades";
            this.listadoDeTareasYPrioridadesToolStripMenuItem.Click += new System.EventHandler(this.listadoDeTareasYPrioridadesToolStripMenuItem_Click);
            // 
            // creacionDeNuevasTareasYObjetivosToolStripMenuItem
            // 
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem.Name = "creacionDeNuevasTareasYObjetivosToolStripMenuItem";
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem.Text = "Creacion de nuevas tareas y objetivos";
            this.creacionDeNuevasTareasYObjetivosToolStripMenuItem.Click += new System.EventHandler(this.creacionDeNuevasTareasYObjetivosToolStripMenuItem_Click);
            // 
            // eliminacionDeTareasToolStripMenuItem
            // 
            this.eliminacionDeTareasToolStripMenuItem.Name = "eliminacionDeTareasToolStripMenuItem";
            this.eliminacionDeTareasToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.eliminacionDeTareasToolStripMenuItem.Text = "Eliminacion de tareas";
            // 
            // reporteDeTareasToolStripMenuItem
            // 
            this.reporteDeTareasToolStripMenuItem.Name = "reporteDeTareasToolStripMenuItem";
            this.reporteDeTareasToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.reporteDeTareasToolStripMenuItem.Text = "Reporte de tareas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(371, 245);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // barraDeEstado
            // 
            this.barraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblUsuarioTS});
            this.barraDeEstado.Location = new System.Drawing.Point(0, 273);
            this.barraDeEstado.Name = "barraDeEstado";
            this.barraDeEstado.Size = new System.Drawing.Size(373, 22);
            this.barraDeEstado.TabIndex = 16;
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
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 295);
            this.Controls.Add(this.barraDeEstado);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPrincipal";
            this.Text = "frmPrincipal";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.barraDeEstado.ResumeLayout(false);
            this.barraDeEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeTareasYPrioridadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creacionDeNuevasTareasYObjetivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminacionDeTareasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeTareasToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.StatusStrip barraDeEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioTS;
    }
}