using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTareas.Controllers
{
    public class TareasXController : ApiController
    {

        //Metodo para Iniciar sesion
        [HttpGet]
        public int IniciarLogin(string username, string pasword)
        {

            string Dtsconection = "Data Source=.;Initial Catalog=TareasX;User ID=sa;Password=123";
            SqlConnection Con = new SqlConnection(Dtsconection);
            Con.Open();

            SqlCommand cmd = new SqlCommand("select * from Usuarios where NameUser='" + username + "' and PassUser = '" + pasword + "'", Con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            return dt.Rows.Count;

        }

        //Metodo para buscar tareas por ID_Tareas
        [HttpGet]
        public DataSet BuscartareaID(int ID_tareas)
        {

            string Dtsconection3 = "Data Source=.;Initial Catalog=TareasX;User ID=sa;Password=123";
            SqlConnection Con3 = new SqlConnection(Dtsconection3);
            Con3.Open();

            SqlDataAdapter CMD3 = new SqlDataAdapter("select * from Tareas where ID_Tarea = '" + ID_tareas + "'", Con3);
            DataSet DS3 = new DataSet();
            CMD3.Fill(DS3);
            return DS3;

        }


        ////Metodo para mostrar tareas
        //[HttpGet]
        //public DataSet MostrarTareas()
        //{

        //    string Dtsconection2 = "Data Source=.;Initial Catalog=TareasX;User ID=sa;Password=123";
        //    SqlConnection Con2 = new SqlConnection(Dtsconection2);
        //    Con2.Open();

        //    SqlDataAdapter CMD2 = new SqlDataAdapter("select * from Tareas", Con2);
        //    DataSet DS2 = new DataSet();
        //    CMD2.Fill(DS2);
        //    return DS2;

        //}


        //Metodo par ainsertar tareas
        [HttpGet]
        public int InsertarTareas(string TituloT, string Ovbeservacion,
                                        string TipoT, string Prioridad,
                                        string estado, string TiempoD, string Fecha)
        {

            int retorn = 0;

            string Dtsconection5 = "Data Source=.;Initial Catalog=TareasX;User ID=sa;Password=123";
            SqlConnection Con5 = new SqlConnection(Dtsconection5);
            Con5.Open();

            SqlCommand Com = new SqlCommand("insert into Tareas " +
                "(Titulo_de_Tarea, Observacion, Tipo_de_Tarea, Nivel_de_Prioridad, Estado, Tiempo_estimado, Fecha) " +
                "values ('" + TituloT + "', '" + Ovbeservacion + "', '" + TipoT + "', '" + Prioridad + "'," +
                " '" + estado + "', '" + TiempoD + "', '" + Fecha + "')", Con5);

            retorn = Com.ExecuteNonQuery();
            return retorn;


        }

    }
}
