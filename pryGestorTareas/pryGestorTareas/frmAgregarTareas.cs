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

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal newobj = new frmPrincipal();
            this.Hide();
            newobj.ShowDialog();
        }
        private void dgvTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya seleccionado una fila válida (no encabezados o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow row = dgvTareas.Rows[e.RowIndex];

                // Asigna los valores de la fila a los controles de edición
                txtNombre.Text = row.Cells["Nombre_Tarea"].Value.ToString();
                txtDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                cmbCategoria.SelectedItem = row.Cells["Categoria"].Value.ToString();
                cmbPrioridad.SelectedItem = row.Cells["Prioridad"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(row.Cells["Fecha_Vencimiento"].Value);
                chkCompletado.Checked = Convert.ToBoolean(row.Cells["Completada"].Value);
            }
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            Int32 Id_Tarea = Convert.ToInt32(txtId_Tarea.Text);
            string Nombre_Tarea = txtNombre.Text;
            string Descripcion_Tarea = txtDescripcion.Text;
            string Categoria = Convert.ToString(cmbCategoria.Text);
            string Prioridad = Convert.ToString(cmbPrioridad.Text);
            bool Completada = chkCompletado.Checked;
            DateTime Fecha = dtpFecha.Value;
            Int32 Id_Usuario = Convert.ToInt32(txtIdUsuario.Text);
            clsBaseDatos MTareas = new clsBaseDatos();
            
            MTareas.Nombre_Tarea = Nombre_Tarea;
            MTareas.Descripcion = Descripcion_Tarea;
            MTareas.Categoria = Categoria;
            MTareas.Prioridad = Prioridad;
            MTareas.fecha_Vencimiento = Fecha;
            MTareas.Id_Usuario = Id_Usuario;
            MTareas.ActualizarTarea(Id_Tarea);
            MessageBox.Show("cliente modificado con exito");
        }

        private void dgvTareas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que se haya seleccionado una fila válida (no encabezados o fuera de rango)
            if (e.RowIndex >= 0)
            {
                // Obtiene la fila seleccionada
                DataGridViewRow row = dgvTareas.Rows[e.RowIndex];

                // Asigna los valores de la fila a los controles de edición
                txtNombre.Text = row.Cells["Column1"].Value.ToString();
                txtDescripcion.Text = row.Cells["Column2"].Value.ToString();
                cmbCategoria.SelectedItem = row.Cells["Column3"].Value.ToString();
                cmbPrioridad.SelectedItem = row.Cells["Column4"].Value.ToString();
                dtpFecha.Value = Convert.ToDateTime(row.Cells["Column5"].Value);
                chkCompletado.Checked = Convert.ToBoolean(row.Cells["Column6"].Value);
            }
        }
    }
}
