using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareasDS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaTareaPage : ContentPage
    {
        public NuevaTareaPage()
        {
            InitializeComponent();

            //Items Tipos de tarea
            TipostareaPicker.Items.Add("Cita");
            TipostareaPicker.Items.Add("Correo electronico");
            TipostareaPicker.Items.Add("Documentacion DS");
            TipostareaPicker.Items.Add("Documento");
            TipostareaPicker.Items.Add("Llamada de atencion");
            TipostareaPicker.Items.Add("Llamada telefonica");
            TipostareaPicker.Items.Add("Prospecto economico");
            TipostareaPicker.Items.Add("Revision");
            TipostareaPicker.Items.Add("Tarea");
            TipostareaPicker.Items.Add("Ticket");

            //Items Nivel de prioridad
            PrioridadPicker.Items.Add("Critico");
            PrioridadPicker.Items.Add("Alto");
            PrioridadPicker.Items.Add("Normal");
            PrioridadPicker.Items.Add("Bajo");

            //Items Estado
            EstaPicker.Items.Add("Activo");
            EstaPicker.Items.Add("Atrasado");
            EstaPicker.Items.Add("Cerrado");
            EstaPicker.Items.Add("Entregado cliente");
            EstaPicker.Items.Add("No procede");
            EstaPicker.Items.Add("Pendiente de negociacion");
            EstaPicker.Items.Add("Revision");

            //Items Tiempo estimado
            TiempoPicker.Items.Add("Minutos");
            TiempoPicker.Items.Add("Horas");
            TiempoPicker.Items.Add("Dias");
            TiempoPicker.Items.Add("Semanas");

        }

        //Declaracion variables, items
        string TiposTar, Prioridad, Estado, Tiempo, Tiempo_estimado;

        //Captura de datos de los Pickers en variables

        //Campo: Tipos de Tareas
        private void TipostareaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiposTar = TipostareaPicker.SelectedItem.ToString();
        }

        //Campo: Prioridad
        private void PrioridadPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prioridad = PrioridadPicker.SelectedItem.ToString();
        }

        //Campo: Estado
        private void EstaPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Estado = EstaPicker.SelectedItem.ToString();
        }

        //Campo: Tiempo Estimado
        private void TiempoPicker_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Tiempo = TiempoPicker.SelectedItem.ToString();
            Tiempo_estimado = (TimpoEntry.Text + " " + Tiempo);
        }



        // Evento boton Guardar Tarea
        private async void GuardarButtom_Clicked(object sender, EventArgs e)
        {
            //validaciones para no permitir campos vacios
            if (String.IsNullOrEmpty(TituloEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un titulo para la tarea", "aceptar");
                TituloEntry.Focus();
                return;
            }

            if (String.IsNullOrEmpty(ObservacionEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una observacion para la tarea", "aceptar");
                ObservacionEntry.Focus();
                return;
            }

            if (String.IsNullOrEmpty(TiposTar))
            {
                await DisplayAlert("Error", "Debe seleccionar un tipo de tarea", "aceptar");
                return;
            }

            if (String.IsNullOrEmpty(Prioridad))
            {
                await DisplayAlert("Error", "Debe seleccionar un nivel de prioridad de tarea", "aceptar");
                return;
            }

            if (String.IsNullOrEmpty(Estado))
            {
                await DisplayAlert("Error", "Debe seleccionar un estado de tarea", "aceptar");
                return;
            }

            if (String.IsNullOrEmpty(TimpoEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar el tiempo estimado para la tarea", "aceptar");
                TimpoEntry.Focus();
                return;
            }

            if (String.IsNullOrEmpty(Tiempo))
            {
                await DisplayAlert("Error", "Debe seleccionar el tiempo estimado para la tarea", "aceptar");
                return;
            }

            //creacion objeto con los campos que se van a insertar 
            var instarea = new Models.Tareas
            {
                Titulo_de_Tarea = TituloEntry.Text,
                Observacion = ObservacionEntry.Text,
                Tipo_de_Tarea = TiposTar,
                Nivel_de_Prioridad = Prioridad,
                Estado = Estado,
                Tiempo_estimado = Tiempo_estimado,
                Fecha = FechaPicker.Date
            };

            //serializar objeto, los campos que se van a insertar en formato Json
            var jsonRequest = JsonConvert.SerializeObject(instarea);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "text/json");


            //Consumo WebApiRest Post (Insertar nueva tarea)
            GuardarButtom.IsEnabled = false;
            string result;

            try
            {

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9280"); //URl donde se publicó el Web
                string url = string.Format("/api/MostrarTareas"); //URL API
                var response = await client.PostAsync(url, content);
                result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception)
            {

                await DisplayAlert("Error", "No hay conexion, intente mas tarde", "Aceptar");
                GuardarButtom.IsEnabled = true;
                return;
            }

            //Si la tarea se inserto correctamente muestra un mensaje
            await DisplayAlert("", "Tarea insertada correctamente", "Aceptar");
            GuardarButtom.IsEnabled = true;

            await Navigation.PushAsync(new InicioPage());

        }

    }
}