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
        private string connectionString;

        public frmListado()
        {
            InitializeComponent();
            CargarTareas();
        }

        private void frmListado_Load(object sender, EventArgs e)
        {
            

        }
        private void CargarTareas()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Tareas", connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable tareasTable = new DataTable();
                    adapter.Fill(tareasTable);

                    // Asigna las tareas a un DataGridView
                    dgvTareas.DataSource = tareasTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas: " + ex.Message);
                }
            }
        }
    }
}
