using System.Text.Json;

namespace Tareas
{
    public class Tarea
    {
        public int userID {get; set;}
        public int id {get; set;}
        public string titulo {get; set;}
        public bool completada {get; set;}
    }
}