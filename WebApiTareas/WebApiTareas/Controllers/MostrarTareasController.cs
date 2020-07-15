using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ConectarDatos.Models;

namespace WebApiTareas.Controllers
{
    public class MostrarTareasController : ApiController
    {

        private TareasXEntities dbContext = new TareasXEntities();

        //Mostrar todas las tareas
        [HttpGet]
        public IEnumerable<Tareas> GetTareas()
        {

            using (TareasXEntities tareasXentities = new TareasXEntities())
            {
                return tareasXentities.Tareas.ToList();
            }

        }

        //Insetar Tareas
        [HttpPost]
        public IHttpActionResult AgregarTareas([FromBody]Tareas tareas)
        {
            if (ModelState.IsValid)
            {
                dbContext.Tareas.Add(tareas);
                dbContext.SaveChanges();
                return Ok(tareas);

            }
            else
            {
                return BadRequest();
            }

        }


        //Mostrar tarea por ID_Tarea
        [HttpGet]
        public Tareas Get (int ID)
        {
            using (TareasXEntities tareasXEntities = new TareasXEntities())
            {
                return tareasXEntities.Tareas.FirstOrDefault(e => e.ID_Tarea == ID);
            }
        }


    }
}
