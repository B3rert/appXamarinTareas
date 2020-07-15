using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasDS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarTareasPage : ContentPage
    {
        private Models.Tareas tareas;

        public MostrarTareasPage(Models.Tareas tareas)
        {
            InitializeComponent();

            //Color Barra de Navegacion 
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.RoyalBlue;
            //Color Texto barra de navegacion
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.White;


            //LLenar campos recuperado en la base de datos (Mostrar tareas)

            //Mostrar ID_Tarea
            if (string.IsNullOrEmpty(tareas.ID_Tarea.ToString()))
            {
                IDLabel.Text = String.Empty;
            }
            else
            {
                IDLabel.Text = tareas.ID_Tarea.ToString();
            }

            //Mostrar Titulo tarea
            if (string.IsNullOrEmpty(tareas.Titulo_de_Tarea))
            {
                TituloLabel.Text = String.Empty;
            }
            else
            {
                TituloLabel.Text = tareas.Titulo_de_Tarea.ToString();
            }

            //Mostrar Observacion
            if (string.IsNullOrEmpty(tareas.Observacion))
            {
                ObservacionLabel.Text = String.Empty;
            }
            else
            {
                ObservacionLabel.Text = tareas.Observacion.ToString();
            }

            //Mostrar Tipo de tarea
            if (string.IsNullOrEmpty(tareas.Tipo_de_Tarea))
            {
                TipoTLabel.Text = String.Empty;
            }
            else
            {
                TipoTLabel.Text = tareas.Tipo_de_Tarea.ToString();
            }

            //Mostrar Nivel de prioridad
            if (string.IsNullOrEmpty(tareas.Nivel_de_Prioridad))
            {
                PrioridadLabel.Text = String.Empty;
            }
            else
            {
                PrioridadLabel.Text = tareas.Nivel_de_Prioridad.ToString();
            }

            //mostra Estado de tarea
            if (string.IsNullOrEmpty(tareas.Estado))
            {
                EstadoLabel.Text = String.Empty;
            }
            else
            {
                EstadoLabel.Text = tareas.Estado.ToString();
            }

            //Mostrar fecha
            FechaPicker.Date = tareas.Fecha;

            //Mostrar tiempo estimado
            if (string.IsNullOrEmpty(tareas.Tiempo_estimado))
            {
                TimpoLabel.Text = String.Empty;
            }
            else
            {
                TimpoLabel.Text = tareas.Tiempo_estimado.ToString();
            }

        }

    }
}