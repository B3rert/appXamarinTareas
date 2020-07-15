using System;
using System.Collections.Generic;
using System.Text;

namespace TareasDS.Models
{
    public class Tareas
    {

        //Clase para la tabla tareas
        public int ID_Tarea { get; set; }
        public string Titulo_de_Tarea { get; set; }
        public string Observacion { get; set; }
        public string Tipo_de_Tarea { get; set; }
        public string Nivel_de_Prioridad { get; set; }
        public string Estado { get; set; }
        public string Tiempo_estimado { get; set; }
        public DateTime Fecha { get; set; }

    }
}
