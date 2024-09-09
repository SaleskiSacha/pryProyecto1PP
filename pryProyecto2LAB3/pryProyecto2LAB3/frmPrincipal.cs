using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryProyecto2LAB3
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void contactosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listarContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListar newobj = new frmListar();
            newobj.ShowDialog();
            this.Hide();
        }

        private void agregarContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregar newobj = new frmAgregar();
            newobj.ShowDialog();
            this.Hide();
        }

        private void eliminarOModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmModificar newobj = new frmModificar();
            newobj.ShowDialog();
            this.Hide();
        }
    }
}
