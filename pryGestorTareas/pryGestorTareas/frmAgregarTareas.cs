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
    public partial class frmAgregarTareas : Form
    {
        public frmAgregarTareas()
        {
            InitializeComponent();
        }
       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsBaseDatos clsBaseDatos = new clsBaseDatos();
            Int32 codi = Convert.ToInt32(txtId_Tarea.Text);
            clsBaseDatos.Buscar(codi);

            if (clsBaseDatos.Id_Tarea != codi)
            {
                clsBaseDatos.Id_Tarea = Convert.ToInt32(txtId_Tarea.Text);
                clsBaseDatos.Nombre_Tarea = txtNombre.Text;
                clsBaseDatos.Descripcion = txtDescripcion.Text;
                clsBaseDatos.Categoria = Convert.ToString(cmbCategoria.Text);
                clsBaseDatos.Prioridad = Convert.ToString(cmbPrioridad.Text);
                clsBaseDatos.Completada = chkCompletado.Checked;
                clsBaseDatos.fecha_Vencimiento = dtpFecha.Value;
                clsBaseDatos.Id_Usuario = Convert.ToInt32(txtIdUsuario.Text);


                clsBaseDatos.AgregarTareas();
                MessageBox.Show("Tarea agregada con éxito");
                txtId_Tarea.Text = "";
                txtNombre.Text = "";
                cmbCategoria.SelectedIndex = 0;
                cmbPrioridad.SelectedIndex = 0;
                txtDescripcion.Text = "";
            }
            else
            {
                MessageBox.Show("TAREA YA REGISTRADO");
                txtId_Tarea.Text = "";
                txtNombre.Text = "";
                cmbCategoria.SelectedIndex = 0;
                cmbPrioridad.SelectedIndex = 0;
                txtDescripcion.Text = "";
            }
        }

        private void frmAgregarTareas_Load(object sender, EventArgs e)
        {
            clsBaseDatos objBaseDatos = new clsBaseDatos();
            clsUsuario objUsuario = new clsUsuario();
            objBaseDatos.ConectarBD();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            clsBaseDatos objBaseDatos = new clsBaseDatos();
            objBaseDatos.ConectarBD();
            objBaseDatos.ListarTareas(dgvTareas);
            objBaseDatos.ListarUsuarios(dgvUsuarios);
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
                clsUsuario clsUsuario = new clsUsuario();
                clsUsuario.Id_Usuario = Convert.ToInt32(txtIdU.Text);
                clsUsuario.Nombre_Usuario = txtNombreUsuario.Text;
                clsUsuario.Tarea_Asignada = Convert.ToInt32(txtTareaAsignada.Text);
                clsUsuario.AgregarUsuario();
                MessageBox.Show("Usuario agregado con éxito");
                txtIdUsuario.Text = "";
                txtTareaAsignada.Text = "";
                txtNombreUsuario.Text = "";
        }
    }
}
