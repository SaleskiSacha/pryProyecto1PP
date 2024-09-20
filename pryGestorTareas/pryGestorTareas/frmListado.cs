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
    public partial class frmListado : Form
    {
        public frmListado()
        {
            InitializeComponent();
        }
        private clsBaseDatos objBaseDatos;
        private void button1_Click(object sender, EventArgs e)
        {
            objBaseDatos.ListarTareas(dgvTareas);
            objBaseDatos.ListarUsuarios(dgvUsuarios);
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsBaseDatos();
            objBaseDatos.ConectarBD();
        }
        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Código para seleccionar y cargar la fila en los controles de edición

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal newobj = new frmPrincipal();
            this.Hide();
            newobj.ShowDialog();
            
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            
        }
    }
}
