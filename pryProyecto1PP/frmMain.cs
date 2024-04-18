using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace pryProyecto1PP
{
    public partial class frmMain : Form
    {
        private Clientes objBaseDatos;
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmAgregarCliente AgregarCliente = new frmAgregarCliente();
            AgregarCliente.ShowDialog();

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            objBaseDatos = new Clientes();
            objBaseDatos.ConectarBD();
            
            lblStatus.Text = objBaseDatos.estadoDeConexion;

            lblStatus.BackColor = Color.Green;
            lblStatus.ForeColor = Color.White;
           
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            objBaseDatos.traerDatos(dgv1);
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgv1.Rows.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Clientes clientes = new Clientes();
            clientes.guardarArchivo();

        }
    }
}
