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
using pryProyecto2Lab3;

namespace pryProyecto2LAB3
{
    public partial class frmListar : Form
    {
        public frmListar()
        {
            InitializeComponent();
        }
        private clsProductos objBaseDatos;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
        
        private void frmListar_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsProductos();
            objBaseDatos.ConectarBD();

        }

        

        private void btnListar_Click(object sender, EventArgs e)
        {
            objBaseDatos.ListarProductos(dgv1);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsProductos clsProductos = new clsProductos();
            Int32 codi = Convert.ToInt32(txtID.Text);
            clsProductos.Buscar(codi);

            if (clsProductos.ID_Contacto != codi)
            {
                clsProductos.ID_Contacto = Convert.ToInt32(txtID.Text);
                clsProductos.Numero = Convert.ToInt32(txtNumero.Text);
                clsProductos.Nombre = (txtNombre.Text);
                clsProductos.Apellido = (txtApellido.Text);
                clsProductos.Correo = (txtCorreo.Text);
                clsProductos.Categoria = (txtCategoria.Text);
                clsProductos.AgregarProducto();
                MessageBox.Show("Contacto agregado con éxito");
                txtID.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCorreo.Text = "";
                txtCategoria.Text = "";
                txtNumero.Text = "";
            }
            else
            {
                MessageBox.Show("Contacto YA REGISTRADO");
                txtID.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtCorreo.Text = "";
                txtCategoria.Text = "";
                txtNumero.Text = "";
            }
        }

        private void mskNumero_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }
    }
}
