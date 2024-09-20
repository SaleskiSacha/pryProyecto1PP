using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace pryGestorTareas
{
    internal class clsBaseDatos
    {
        OleDbConnection conexionBD = new OleDbConnection();
        OleDbCommand comandoBD = new OleDbCommand();
        OleDbDataReader lectorBD;
        OleDbDataAdapter adaptadorBD = new OleDbDataAdapter();
        //DataSet objDS;

        string cadenaDeConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\Tarea.accdb";

        public string EstadoDeConexion = "";
        private string Tabla = "Tareas";
        private string Tabla2 = "Usuarios";

        Int32 id_t;
        string nom;
        string des;
        string cate;
        string prio;
        DateTime fe;
        bool com;
        Int32 id_u;

        public Int32 Id_Tarea
        {
            get { return id_t; }
            set { id_t = value; }
        }
        public string Prioridad
        {
            get { return prio; }
            set { prio = value; }
        }
        public string Nombre_Tarea
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Categoria
        {
            get { return cate; }
            set { cate = value; }
        }
        public DateTime fecha_Vencimiento
        {
            get { return fe; }
            set { fe = value; }
        }
        public string Descripcion
        {
            get { return des; }
            set { des = value; }
        }
        public bool Completada
        {
            get { return com; }
            set { com = value; }
        }
        public Int32 Id_Usuario
        {
            get { return id_u; }
            set { id_u = value; }
        }
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
        public void ListarTareas(DataGridView grilla)
        {
            
            comandoBD = new OleDbCommand();
           
            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = CommandType.TableDirect;
            comandoBD.CommandText = Tabla;
            
            grilla.Rows.Clear();
            lectorBD = comandoBD.ExecuteReader();
            clsBaseDatos clsBaseDatos = new clsBaseDatos();
            if (lectorBD.HasRows)
            {
                while (lectorBD.Read())
                {
                    
                    grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[5], lectorBD[6], lectorBD[7]);

                }
            }
            
        }
        public void ListarUsuarios(DataGridView grilla)
        {

            comandoBD = new OleDbCommand();

            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = CommandType.TableDirect;
            comandoBD.CommandText = Tabla2;

            grilla.Rows.Clear();
            lectorBD = comandoBD.ExecuteReader();
            clsBaseDatos clsBaseDatos = new clsBaseDatos();
            if (lectorBD.HasRows)
            {
                while (lectorBD.Read())
                {

                    grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2]);

                }
            }
        }
        public void Buscar(Int32 i) 
        {
            OleDbConnection conexionBD = new OleDbConnection();
            OleDbCommand comandoBD = new OleDbCommand();

            try
            {
                conexionBD.ConnectionString = cadenaDeConexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = Tabla;

                OleDbDataReader Lector = comandoBD.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        if (Lector.GetInt32(0) == i)
                        {
                            Id_Tarea = Lector.GetInt32(0);
                            Nombre_Tarea = Lector.GetString(1);
                            Descripcion = Lector.GetString(2);
                            Categoria = Lector.GetString(3);
                            Prioridad = Lector.GetString(4);
                            fecha_Vencimiento = Lector.GetDateTime(5);
                            Completada = Lector.GetBoolean(6);
                            Descripcion = Lector.GetString(7);
                        }
                    }
                }

                conexionBD.Close();
            }
            catch (Exception MensajeAviso)
            {
                MessageBox.Show(MensajeAviso.Message);
            }
        }
        public void AgregarTareas() 
        {
            try
            {
                conexionBD.ConnectionString = cadenaDeConexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = Tabla;

                adaptadorBD = new OleDbDataAdapter(comandoBD);
                DataSet DS = new DataSet();
                //LLENA EL DATA SET CON LOS DATOS DE LA TABLA
                adaptadorBD.Fill(DS, Tabla);
                //RECIBE LOS DATOS
                DataTable tabla = DS.Tables[Tabla];
                DataRow Fila = tabla.NewRow();

                Fila["Id_Tarea"] = Id_Tarea;
                Fila["Nombre_Tarea"] = Nombre_Tarea;
                Fila["Descripcion"] = Descripcion;
                Fila["Categoria"] = Categoria;
                Fila["Prioridad"] = Prioridad;
                Fila["Fecha_Vencimiento"] = fecha_Vencimiento;
                Fila["Completada"] = Completada;
                Fila["Id_Usuario"] = Id_Usuario;
                
                

                tabla.Rows.Add(Fila);

                OleDbCommandBuilder HacerCompatiblesLosCambios = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(DS, Tabla);
                conexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo registrar la Tarea", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ActualizarTarea(Int32 Id_Tarea) 
        {
            using (OleDbConnection connection = new OleDbConnection(cadenaDeConexion))
            {
                try
                {
                    connection.Open();

                    string query = "UPDATE Tareas SET " + 
                                    " Nombre_Tarea = @Nombre_Tarea, " + 
                                    "Descripcion = @Descripcion, " +
                                   "Categoria = @Categoria, " + 
                                   "Prioridad = @Prioridad," +
                                   "fecha_Vencimiento = @fecha_Vencimiento, " +
                                   "Completada = @Completada," + 
                                   "Id_Usuario = @Id_Usuario " +
                                   " WHERE Id_Tarea = @Id_Tarea";

                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("@Nombre_Tarea", Nombre_Tarea);
                    command.Parameters.AddWithValue("@Descripcion", Descripcion);
                    command.Parameters.AddWithValue("@Categoria", Categoria);
                    command.Parameters.AddWithValue("@Prioridad", Prioridad);
                    command.Parameters.AddWithValue("@fecha_Vencimiento", fecha_Vencimiento);
                    command.Parameters.AddWithValue("@Completada", Completada);
                    command.Parameters.AddWithValue("@Id_Usuario", Id_Usuario);
                    command.Parameters.AddWithValue("@Id_Tarea", Id_Tarea);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar la tarea: " + ex.Message);
                }
            }
        }
    }
}
