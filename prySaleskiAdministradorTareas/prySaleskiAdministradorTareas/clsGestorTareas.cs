using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prySaleskiAdministradorTareas
{
    internal class clsGestorTareas
    {
        public List<clsTareasBD> Tareas { get; private set; } = new List<clsTareasBD>();
        public List<Usuario> Usuarios { get; private set; } = new List<Usuario>();

        public void CrearUsuario(string nombre)
        {
           // Usuarios.Add(new clsUsuario(nombre));
        }

        public void CrearTarea(string nombre, string descripcion, string categoria, string prioridad, DateTime fechaVencimiento, Int32 ID_Usuario)
        {
            
        }

        public void AsignarTarea(int tareaIndex, clsUsuario usuario)
        {
            Tareas[tareaIndex].AsignadoA = usuario;
        }

        public void CompletarTarea(int tareaIndex)
        {
            Tareas[tareaIndex].Completada = true;
        }

        public List<clsTareasBD> ObtenerTareasPorVencer()
        {
            return Tareas.Where(t => t.EstaPorVencer() && !t.Completada).ToList();
        }
    }
}
