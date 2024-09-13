using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace prySaleskiAdministradorTareas
{
    public partial class frmListado : Form
    {
        
        clsTareasBD objBaseDatos;

        public frmListado()
        {
            InitializeComponent();
            
            
            
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
           

        }

        private void btnAgregarTarea_Click(object sender, EventArgs e)
        {
            string nombreTarea = txtNombreTarea.Text;
            string descripcion = txtDescripcion.Text;
            string categoria = cmbCategorias.SelectedItem.ToString();
            string prioridad = cmbPrioridad.SelectedItem.ToString();
            DateTime fechaVencimiento = dtpVencimiento.Value;
            int usuarioID = (int)cmbUsuario.SelectedValue; // Asumiendo que comboboxUsuarios tiene el ID de usuario

            // Llamar al método que inserta la tarea en la base de datos
            //InsertarTarea(nombreTarea, descripcion, categoria, prioridad, fechaVencimiento, usuarioID);
            //CargarTareas(); // Actualizar la lista de tareas en el DataGridView
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int tareaID = Convert.ToInt32(dgvTareas.SelectedRows[0].Cells["ID_Tarea"].Value);
                int usuarioID = (int)cmbUsuario.SelectedValue; // Selecciona el usuario

                //clsTareasBD.AsignarTarea(tareaID, usuarioID);
                //CargarTareas(); // Actualizar la vista
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            if (dgvTareas.SelectedRows.Count > 0)
            {
                int tareaID = Convert.ToInt32(dgvTareas.SelectedRows[0].Cells["ID_Tarea"].Value);

                //CompletarTarea(tareaID);
                //CargarTareas(); // Actualizar la vista
            }
        }
    }
}
