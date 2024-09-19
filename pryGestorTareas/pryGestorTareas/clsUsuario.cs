using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace pryGestorTareas
{
    internal class clsUsuario
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
        Int32 id_u;
        Int32 ta;
        string nom;
        public Int32 Id_Usuario
        {
            get { return id_u; }
            set { id_u = value; }
        }
        public Int32 Tarea_Asignada
        {
            get { return ta; }
            set { ta = value; }
        }
        public string Nombre_Usuario
        {
            get { return nom; }
            set { nom = value; }
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
                comandoBD.CommandText = Tabla2;

                OleDbDataReader Lector = comandoBD.ExecuteReader();
                if (Lector.HasRows)
                {
                    while (Lector.Read())
                    {
                        if (Lector.GetInt32(0) == i)
                        {
                            Id_Usuario = Lector.GetInt32(0);
                            Nombre_Usuario = Lector.GetString(1);
                            Tarea_Asignada = Lector.GetInt32(2);
                           
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
        public void AgregarUsuario()
        {
            try
            {
                conexionBD.ConnectionString = cadenaDeConexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = Tabla2;
                adaptadorBD = new OleDbDataAdapter(comandoBD);
                DataSet DS = new DataSet();
                //LLENA EL DATA SET CON LOS DATOS DE LA TABLA
                adaptadorBD.Fill(DS, Tabla2);
                //RECIBE LOS DATOS
                DataTable tabla = DS.Tables[Tabla2];
                DataRow Fila = tabla.NewRow();  
                Fila["Id_Usuario"] = Id_Usuario;
                Fila["Nombre_Usuario"] = Nombre_Usuario;
                Fila["Tarea_Asignada"] = Tarea_Asignada;
                tabla.Rows.Add(Fila);
                OleDbCommandBuilder HacerCompatiblesLosCambios = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(DS, Tabla2);
                conexionBD.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo registrar el Usuario", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
