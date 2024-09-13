using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace prySaleskiAdministradorTareas
{
    internal class clsTareasBD
    {
        OleDbConnection conexionBD = new OleDbConnection();
        OleDbCommand comandoBD = new OleDbCommand();
        OleDbDataReader lectorBD;
        OleDbDataAdapter adaptadorBD = new OleDbDataAdapter();
        //DataSet objDS;

        string cadenaDeConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\Tareas.accdb";

        public string EstadoDeConexion = "";
        private string Tabla = "Tareas";
        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenaDeConexion;
                conexionBD.Open();
                EstadoDeConexion = "Conectado";
            }
            catch (Exception ex)
            {
                EstadoDeConexion = "Error" + ex.Message;
            }

        }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public string Prioridad { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public clsUsuario AsignadoA { get; set; }
        public bool Completada { get; set; }
        
        public Int32 id { get; set; }

        public clsTareasBD(string nombre, string descripcion, string categoria, string prioridad, DateTime fechaVencimiento, Int32 ID_Usuario)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Categoria = categoria;
            Prioridad = prioridad;
            FechaVencimiento = fechaVencimiento;
            Completada = false; // Inicia como pendiente
        }
        private void InsertarTarea(string nombreTarea, string descripcion, string categoria, string prioridad, DateTime fechaVencimiento, int idUsuario)
        {
            // Ruta de la base de datos Access (asegúrate de colocar el archivo .accdb en la ubicación correcta)
            

            using (OleDbConnection connection = new OleDbConnection(cadenaDeConexion))
            {
                try
                {
                    // Abrimos la conexión
                    connection.Open();

                    // Comando SQL para insertar la tarea
                    string query = "INSERT INTO Tareas (Nombre_Tarea, Descripcion, Categoria, Prioridad, Fecha_Vencimiento, ID_Usuario, Completada) " +
                                   "VALUES (@Nombre, @Descripcion, @Categoria, @Prioridad, @FechaVencimiento, @ID_Usuario, @Completada)";

                    // Creamos el comando
                    OleDbCommand command = new OleDbCommand(query, connection);

                    // Asignamos los parámetros
                    command.Parameters.AddWithValue("@Nombre", nombreTarea);
                    command.Parameters.AddWithValue("@Descripcion", descripcion);
                    command.Parameters.AddWithValue("@Categoria", categoria);
                    command.Parameters.AddWithValue("@Prioridad", prioridad);
                    command.Parameters.AddWithValue("@FechaVencimiento", fechaVencimiento);
                    command.Parameters.AddWithValue("@ID_Usuario", idUsuario);
                    command.Parameters.AddWithValue("@Completada", false); // Inicia como no completada

                    // Ejecutamos el comando
                    command.ExecuteNonQuery();

                    MessageBox.Show("Tarea insertada exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la tarea: " + ex.Message);
                }
            }
        }
        public bool EstaPorVencer()
        {
            return (FechaVencimiento - DateTime.Now).TotalDays <= 1;
        }
        public void CargarTareas(DataGridView grilla)
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaDeConexion))
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM Tareas", connection);
                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable tareasTable = new DataTable();
                    adapter.Fill(tareasTable);

                    // Asigna las tareas a un DataGridView
                    grilla.DataSource = tareasTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas: " + ex.Message);
                }
            }
        }

    }
}
