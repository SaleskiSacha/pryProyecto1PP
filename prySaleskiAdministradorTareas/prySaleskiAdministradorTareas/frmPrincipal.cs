using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prySaleskiAdministradorTareas
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void listadoDeTareasYPrioridadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListado frmListado = new frmListado();
            this.Hide();
            frmListado.Show();
        }

        private void creacionDeNuevasTareasYObjetivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABM frmABM = new frmABM();
            this.Hide();
            frmABM.Show();
        }
        clsTareasBD objBaseDatos;
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            //objBaseDatos = new clsTareasBD();
            objBaseDatos.ConectarBD();
            lblStatus.Text = objBaseDatos.EstadoDeConexion;
            lblStatus.BackColor = Color.Green;
            lblStatus.ForeColor = Color.White;
        }
    }
}
