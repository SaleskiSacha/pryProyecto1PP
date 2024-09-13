using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace pryProyecto2Lab3
{
    internal class clsContactos
    {


        OleDbConnection conexionBD = new OleDbConnection();
        OleDbCommand comandoBD = new OleDbCommand();
        OleDbDataReader lectorBD;
        OleDbDataAdapter adaptadorBD = new OleDbDataAdapter();
        //DataSet objDS;

        string cadenaDeConexion = @"Provider = Microsoft.ACE.OLEDB.12.0;" + " Data Source = ..\\..\\Resources\\Contacto.accdb";

        public string EstadoDeConexion = "";
        private string Tabla = "Contactos";
        Int32 num;
        string nom;
        string ape;
       
        string cate;
        string co;
        Int32 id;
        public Int32 ID_Contacto
        {
            get { return id; }
            set { id = value; }
        }
        public Int32 Numero 
        {
            get { return num; }
            set { num = value;  }
        }
        public string Apellido
        {
            get { return ape; }
            set { ape = value; }
        }
        public string Nombre
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Categoria
        {
            get { return cate; }
            set { cate = value; }
        }
       
        public string Correo
        {
            get { return co; }
            set { co = value; }
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

        public void AgregarProducto() 
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
                Fila["ID_Contacto"] = ID_Contacto;
                Fila["Numero"] = Numero;
                Fila["Nombre"] = Nombre;
                Fila["Apellido"] = Apellido;
                Fila["Correo"] = Correo;
                Fila["Categoria"] = Categoria;
                

                tabla.Rows.Add(Fila);

                OleDbCommandBuilder HacerCompatiblesLosCambios = new OleDbCommandBuilder(adaptadorBD);
                adaptadorBD.Update(DS, Tabla);
                conexionBD.Close();
            }
            catch (Exception ) 
            {
                MessageBox.Show("No se pudo registrar cliente", "ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            ID_Contacto = Lector.GetInt32(0);
                            Numero = Lector.GetInt32(1);
                            Nombre = Lector.GetString(2);
                            Apellido = Lector.GetString(3);
                            Correo = Lector.GetString(4);
                            Categoria = Lector.GetString(5);
                            
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
        
        public void EliminarProducto(Int32 CodigoProducto)
        {
            try
            {
                string EProducto = " DELETE FROM Productos " + "WHERE(" + CodigoProducto + "=[Numero])";
                conexionBD.ConnectionString = cadenaDeConexion;
                conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.Text;
                comandoBD.CommandText = EProducto;
                comandoBD.ExecuteNonQuery();
                conexionBD.Close();
                MessageBox.Show("Producto Eliminado con éxito");
            }
            catch (Exception Mensaje)
            {
                MessageBox.Show("El cliente no se pudo eliminar " + Mensaje.Message);
                //throw;
            }
        }
        public void ModificarContacto( Int32 NumeroContacto) 
        {
            try
            {
                using (OleDbConnection conexionBD = new OleDbConnection(cadenaDeConexion))
                {
                    conexionBD.Open();

                    // Sentencia SQL para modificar el producto con parámetros
                    string MContacto = "UPDATE Productos SET " +
                                       "Nombre = @Nombre, " +
                                       "Apellido = @Apellido, " +
                                       "Correo = @Correo, " +
                                       "Categoria = @Categoria, " +
                                       "Numero = @Numero," +
                                       "WHERE ID_Contacto = @ID_Contacto";

                    using (OleDbCommand comandoBD = new OleDbCommand(MContacto, conexionBD))
                    {
                        // Asignar los valores a los parámetros
                        comandoBD.Parameters.AddWithValue("@Nombre", Nombre);
                        comandoBD.Parameters.AddWithValue("@Precio", Apellido);
                        comandoBD.Parameters.AddWithValue("@Stock", Correo);
                        comandoBD.Parameters.AddWithValue("@Categoria", Categoria);
                        
                        comandoBD.Parameters.AddWithValue("@Codigo", NumeroContacto);

                        // Ejecutar la actualización
                        comandoBD.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("el Producto no se pudo Modificar ");
                //throw;
                
            }
        }
        public void ListarProductos(DataGridView grilla) 
        {
            //try
            //{
                comandoBD = new OleDbCommand();
                //conexionBD.ConnectionString = cadenaDeConexion;
                //conexionBD.Open();
                comandoBD.Connection = conexionBD;
                comandoBD.CommandType = CommandType.TableDirect;
                comandoBD.CommandText = Tabla;
                //OleDbDataReader DR = comandoBD.ExecuteReader();
                grilla.Rows.Clear();
                lectorBD = comandoBD.ExecuteReader();
                clsContactos clsProductos = new clsContactos();
                if (lectorBD.HasRows)
                {
                    while (lectorBD.Read())
                    {
                    //grilla.Rows.Add(lectorBD.GetInt32(0), lectorBD.GetString(1), lectorBD.GetDecimal(2), lectorBD.GetInt32(3), lectorBD.GetString(4), lectorBD.GetString(5));
                        grilla.Rows.Add(lectorBD[0], lectorBD[1], lectorBD[2], lectorBD[3], lectorBD[4], lectorBD[5]);

                    }
                }
                //conexionBD.Close();
            //}
            //catch (Exception Mensaje)
            //{
                //MessageBox.Show(Mensaje.Message);
                //throw;
            //}
        }
        public Dictionary<string, int> ObtenerNivelesDeStock() 
        {
            Dictionary<string, int> nivelesDeStock = new Dictionary<string, int>();
            try
            {
                using (OleDbConnection conexionBD = new OleDbConnection(cadenaDeConexion))
                {
                    conexionBD.Open();

                    // Consulta SQL para obtener el nombre y stock de cada producto
                    string query = "SELECT Nombre, Stock FROM Productos";

                    using (OleDbCommand comandoBD = new OleDbCommand(query, conexionBD))
                    {
                        OleDbDataReader lector = comandoBD.ExecuteReader();
                        while (lector.Read())
                        {
                            string nombreProducto = lector.GetString(0);
                            int stockProducto = lector.GetInt32(1);
                            nivelesDeStock[nombreProducto] = stockProducto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                System.Windows.Forms.MessageBox.Show("Ocurrió un error al obtener los niveles de stock: " + ex.Message);
            }
            return nivelesDeStock;
        }
    }
}
