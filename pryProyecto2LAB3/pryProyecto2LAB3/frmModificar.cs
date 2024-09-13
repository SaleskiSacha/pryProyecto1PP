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
    public partial class frmModificar : Form
    {
        public frmModificar()
        {
            InitializeComponent();
        }
        clsContactos objProductos = new clsContactos();
        private clsContactos objBaseDatos;
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            LimpiarComandos();
            Int32 Codigo = Convert.ToInt32(txtBuscar.Text);
            clsContactos EProdcuto = new clsContactos();
            EProdcuto.EliminarProducto(Codigo);
            txtid.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtCategoria.Text = "";
            txtNumero.Text = "";
        }
        private void LimpiarComandos() 
        {
            txtid.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtCategoria.Text = "";
            txtNumero.Text = "";
        }
        private void Habilitar()
        {
            if (txtBuscar.Text == "")
            {
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;
            }
            else
            {
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Int32 ID = Convert.ToInt32(txtNumero.Text);
            Int32 Numero = Convert.ToInt32(txtNumero.Text);
            string Nombre = (txtNombre.Text);
            
            string Apellido = (txtApellido.Text);
            string Correo = (txtCorreo.Text);
            string Categoria = (txtCategoria.Text);
            

            clsContactos EProdcuto = new clsContactos();
            EProdcuto.ID_Contacto = ID;
            EProdcuto.Numero = Numero;
            EProdcuto.Nombre = Nombre;
            
            EProdcuto.Apellido = Apellido;
            EProdcuto.Correo = Correo;
            EProdcuto.Categoria = Categoria;
            
            EProdcuto.ModificarContacto(ID);

            txtid.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtCorreo.Text = "";
            txtCategoria.Text = "";
            txtNumero.Text = "";
            MessageBox.Show("Producto modificado con éxito");
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;


            txtNombre.ReadOnly = false;
            txtNumero.ReadOnly = false;
            txtid.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtCategoria.ReadOnly = false;
            txtApellido.ReadOnly = false;
        }
        private void Limpiar()
        {

            txtNombre.Text = "";
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtid.ReadOnly = true;
            txtNumero.ReadOnly = true;
            txtCategoria.ReadOnly = true;
            txtCorreo.ReadOnly = true;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = false;

        }
        private void frmModificar_Load(object sender, EventArgs e)
        {
            clsContactos Productos = new clsContactos();
            Limpiar();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Int32 codi = Convert.ToInt32(txtBuscar.Text);
            clsContactos Productos = new clsContactos();
            Productos.Buscar(codi);
            if (Productos.ID_Contacto != codi)
            {
                MessageBox.Show("El Producto no se encuentra registrado");
                txtBuscar.Text = "";
            }
            else
            {
                txtid.Text = Convert.ToString(Productos.ID_Contacto);
                txtNumero.Text = Convert.ToString(Productos.Numero);
                txtNombre.Text = Productos.Nombre;
                txtApellido.Text = Productos.Apellido;
                txtCorreo.Text = Convert.ToString(Productos.Correo);
                txtCategoria.Text = Productos.Categoria;
                
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            Habilitar();
        }
    }
}
