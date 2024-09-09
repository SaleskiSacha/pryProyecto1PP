using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace pryProyecto1PP
{
    public partial class frmAgregarCliente : Form
    {
        public frmAgregarCliente()
        {
            InitializeComponent();
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            Clientes clientes = new Clientes();
            Int32 IDcliente = Convert.ToInt32(txtID.Text); 
            clientes.Buscar(IDcliente);

            if (clientes.ID != IDcliente)
            {
                clientes.ID = Convert.ToInt32(txtID.Text);
                clientes.Apellido = (txtApellido.Text);
                clientes.Pais = (txtNacionalidad.Text);
                clientes.Nombre = (txtNombre.Text);
                clientes.agregarClientes();
                
                MessageBox.Show("Cliente registrado con exito");
                txtID.Text = "";
                txtApellido.Text = "";
                txtNacionalidad.Text = "";
                txtNombre.Text = "";

            }
            else
            {
                MessageBox.Show("El cliente ya se encuentra registrado");
                txtID.Text = "";
                txtApellido.Text = "";
                txtNacionalidad.Text = "";
                txtNombre.Text = "";
            }
        }

        private void frmAgregarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
