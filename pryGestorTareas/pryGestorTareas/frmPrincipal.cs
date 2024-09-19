using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryGestorTareas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        clsBaseDatos objBaseDatos;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            objBaseDatos.ConectarBD();
            lblStatus.Text = objBaseDatos.EstadoDeConexion;
            lblStatus.BackColor = Color.Green;
            lblStatus.ForeColor = Color.White;
        }

        private void listadoDeTareasYPrioridadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListado newobjt = new frmListado();
            newobjt.ShowDialog();
            this.Close();
        }

        private void creacionDeNuevasTareasYObjetivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarTareas newobj = new frmAgregarTareas();
            newobj.ShowDialog();  
           this.Hide();
        }
    }
}
