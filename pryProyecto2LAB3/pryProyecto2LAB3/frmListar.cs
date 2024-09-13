using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using pryProyecto2Lab3;

namespace pryProyecto2LAB3
{
    public partial class frmListar : Form
    {
        
        public frmListar()
        {
            InitializeComponent();
           
            LlenarTreeView();
        }
        private clsContactos objBaseDatos;
        
        private void frmListar_Load(object sender, EventArgs e)
        {
            objBaseDatos = new clsContactos();
            objBaseDatos.ConectarBD();

        }
        DirectoryInfo info;
        private void LlenarTreeView() //este procedimiento me rellena el treeview
        {
            TreeNode nodoMadre;

            info = new DirectoryInfo(@"../../Resources/Contenidos");
            if (info.Exists == true) //POR DEFECTO el IF pregunta true
            {
                nodoMadre = new TreeNode(info.Name);
                nodoMadre.Tag = info;
                ObtenerCarpetas(info.GetDirectories(), nodoMadre);
                treeView1.Nodes.Add(nodoMadre);
            }
        }
        private void ObtenerCarpetas(DirectoryInfo[] subDirs,  //este procedimiento me obtiene las carpetas del nodo madre en este caso las carpetas que estan dentro de proovedores
   TreeNode nodeToAddTo)
        {
            TreeNode aNode;
            DirectoryInfo[] subSubDirs;


            foreach (DirectoryInfo subDir in subDirs)
            {
                aNode = new TreeNode(subDir.Name, 0, 0);
                aNode.Tag = subDir;
                

                // Obtener archivos en lugar de solo carpetas
                FileInfo[] files = subDir.GetFiles();
                foreach (FileInfo file in files)
                {
                    TreeNode fileNode = new TreeNode(file.Name, 1, 1); // Usar una imagen para archivos
                    fileNode.Tag = file;
                    aNode.Nodes.Add(fileNode);
                }

                //recursiva - se llama a si mismo para
                //buscar màs carpetas
                subSubDirs = subDir.GetDirectories();
                if (subSubDirs.Length != 0)
                {
                    ObtenerCarpetas(subSubDirs, aNode);
                }

                nodeToAddTo.Nodes.Add(aNode);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            objBaseDatos.ListarProductos(dgvListado);
        }

       

        private void mskNumero_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string leerLinea;
        string[] separarDatos;
        private void treeView1_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmPrincipal newobj = new frmPrincipal();
            this.Close();
            this.Hide();
            newobj.ShowDialog();
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            dgvListado.Rows.Clear();
            dgvListado.Columns.Clear();

            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                // Obtener la ruta completa del archivo CSV
                string archivoSeleccionado = Convert.ToString(treeView1.SelectedNode.FullPath);
                DirectoryInfo info = new DirectoryInfo(@"../../Resources");
                string ruta = info.FullName;

                // Nombre del archivo CSV (ubicado en el nodo)
                string nombreArchivo = treeView1.SelectedNode.Text;

                try
                {
                    // Combinar la ruta y el archivo seleccionado
                    string rutaCompleta = Path.Combine(ruta, archivoSeleccionado);

                    // Leer el archivo CSV
                    using (StreamReader sr = new StreamReader(rutaCompleta))
                    {
                        string leerLinea = sr.ReadLine();
                        if (leerLinea != null)
                        {
                            // Separar los encabezados de la primera línea
                            string[] separarDatos = leerLinea.Split(';');

                            // Agregar columnas al DataGridView
                            for (int indice = 0; indice < separarDatos.Length; indice++)
                            {
                                dgvListado.Columns.Add(separarDatos[indice], separarDatos[indice]);
                            }

                            // Leer las filas del CSV y agregarlas a la grilla
                            while (!sr.EndOfStream)
                            {
                                leerLinea = sr.ReadLine();
                                separarDatos = leerLinea.Split(';');
                                dgvListado.Rows.Add(separarDatos);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El archivo no tiene registros.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el archivo: " + ex.Message);
                }
            }
        }
    }
}
