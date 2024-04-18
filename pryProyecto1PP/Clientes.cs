using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.Common;



namespace pryProyecto1PP
{
    internal class Clientes
    {
        OleDbConnection conexionBD = new OleDbConnection();
        OleDbCommand comandoBD = new OleDbCommand();
        OleDbDataReader lectorBD;
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        DataSet objDataSet = new DataSet();

        string cadenadeconexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\Clientes.accdb";
        public string estadoDeConexion = "";
        private string Nom;
        private string Pa;
        private string Ape;
        private Int32 id;
        private string clientes = "Cliente";

        public Int32 ID 
        {
            get { return id; }
            set { id = value; }
        }
        public string Nombre 
        {
            get { return Nom; }
            set { Nom = value; }
        }
        public string Apellido 
        {
            get { return Ape; }
            set { Ape = value; }
        }
        public string Pais 
        {
            get { return Pa; }
            set { Pa = value; }
        }

        public void ConectarBD()
        {
            try
            {
                conexionBD = new OleDbConnection();
                conexionBD.ConnectionString = cadenadeconexion;
                conexionBD.Open();
                estadoDeConexion = "Conectado";
            }
            catch (Exception ex)
            {
                estadoDeConexion = "Error" + ex.Message;
            }
        }
        public void traerDatos(DataGridView grilla)
        {
            comandoBD = new OleDbCommand();
            grilla.Rows.Clear();
            comandoBD.Connection = conexionBD;
            comandoBD.CommandType = System.Data.CommandType.TableDirect;
            comandoBD.CommandText = "Cliente";
            lectorBD = comandoBD.ExecuteReader();
           
            if (lectorBD.HasRows) 
            {
                while (lectorBD.Read())
                {
                    grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3]);
                }
            }

        }
        public void agregarClientes()
        {
            try
            {
                conexionBD.ConnectionString = cadenadeconexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = clientes;
                adapter = new OleDbDataAdapter(comandoBD);
                DataSet ds = new DataSet();
                adapter.Fill(ds, clientes);
                DataTable Clientes = ds.Tables[clientes];
                DataRow Fila = Clientes.NewRow();
                Fila["ID"] = id;
                Fila["Apellido"] = Ape;
                Fila["Pais"] = Pa;
                Fila["Nombre"] = Nom;
                Clientes.Rows.Add(Fila);
                OleDbCommandBuilder HacerCompatiblesLosCambios = new OleDbCommandBuilder(adapter);
                adapter.Update(ds, clientes);
                conexionBD.Close();


            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo registrar el cliente", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }   
            


        }
        public void Buscar(Int32 codigo) 
        {
            try
            {
                conexionBD.ConnectionString = cadenadeconexion;
                conexionBD.Open();
                
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = clientes;
                OleDbDataReader LectorBD = comandoBD.ExecuteReader();
                if (LectorBD.HasRows)
                {
                    while (LectorBD.Read())
                    {
                        if (LectorBD.GetInt32(0) == codigo)
                        {
                            ID = LectorBD.GetInt32(0);
                            Apellido = LectorBD.GetString(1);
                            Pais = LectorBD.GetString(2);
                            Nombre = LectorBD.GetString(3);

                        }
                    }
                }
                conexionBD.Close();
            }
            catch (Exception MensajeAviso)
            {
                MessageBox.Show(MensajeAviso.Message);
                //throw;
            }
        }
        public void guardarArchivo()
        {
            try
            {

                conexionBD.ConnectionString = cadenadeconexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = clientes;
                OleDbDataReader DR = comandoBD.ExecuteReader();
                using (StreamWriter sw = new StreamWriter("datos.txt", false))
                {
                    sw.WriteLine("Listado de clientes\n"); //n es para el salto de linea
                    sw.WriteLine();
                    sw.WriteLine("ID;Apellido;Pais;Nombre");
                    if (DR.HasRows)
                    {
                        while (DR.Read())
                        {
                            sw.Write(DR.GetInt32(0));
                            sw.Write(";");
                            sw.Write(DR.GetString(1));
                            sw.Write(";");
                            sw.Write(DR.GetString(2));
                            sw.Write(";");
                            sw.Write(DR.GetString(3));
                            sw.Write("\n");
                        }
                    }
                    conexionBD.Close();
                    sw.Close();
                    MessageBox.Show("Guardado con exito");
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

    }
}
