using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

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
        Int32 id;
        string nom;
        string de;
        string prio;
        Int32 fe;
        Int32 id_u;
        string cat;
        Int32 ID_Tarea { get { return id; } set { id = value; } }
        Int32 FechaVencimiento { get { return fe; } set { fe = value; } }
        Int32 ID_Usuario { get { return id_u; } set { id_u = value; } }
        string NombreTarea { get { return nom; } set { nom = value; } }
        string Categoria { get { return cat; } set { cat = value; } }
        string Descripcion { get { return de; } set { de = value; } }
        string Prioridad { get { return prio; } set { prio = value; } }
        public void InsertarTareas()
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaDeConexion))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Tareas (Nombre_Tarea, Descripcion, Categoria, Prioridad, Fecha_Vencimiento, ID_Usuario, Completada) " +
                                   "VALUES (@Nombre, @Descripcion, @Categoria, @Prioridad, @FechaVencimiento, @ID_Usuario, @Completada)";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", NombreTarea);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@Categoria", Categoria);
                    command.Parameters.AddWithValue("@Prioridad", Prioridad);
                    command.Parameters.AddWithValue("@FechaVencimiento", FechaVencimiento);
                    command.Parameters.AddWithValue("@ID_Usuario", ID_Usuario);
                    command.Parameters.AddWithValue("@Completada", false); // Inicia como no completada

                    command.ExecuteNonQuery();
                    MessageBox.Show("Tarea insertada exitosamente.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al insertar la tarea: " + ex.Message);
                }
            }
        }
        
    }
}
