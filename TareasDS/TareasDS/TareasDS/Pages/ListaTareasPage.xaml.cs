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
    public partial class ListaTareasPage : ContentPage
    {
        //Lista de la clase tareas, tabla de tareas
        private List<Models.Tareas> Tareas;

        public ListaTareasPage()
        {
            InitializeComponent();

            //Personalizar ListView de la clase TareasCells
            TareasList.ItemTemplate = new DataTemplate(typeof(Cells.TareasCell));

            this.LoadTareas();

        }

        private async void LoadTareas()
        {
            //Cargar tareas por consumo WebApiRest

            string result;

            //Manejo de errores
            try
            {
                WaitActivity.IsRunning = true;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9280");  //URl donde se publicó el Web
                string url = string.Format("/api/MostrarTareas"); //URl Api
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;

                WaitActivity.IsRunning = false;
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No hay conexion, intente mas tarde", "Aceptar");

                WaitActivity.IsRunning = false;

                return;
            }

            //Deserealizar la lista de tareas Json
            Tareas = JsonConvert.DeserializeObject<List<Models.Tareas>>(result);
            //Añadir las tareas a list view
            TareasList.ItemsSource = Tareas;
        }

        //Evento al tocar un elemento de la lista de tareas
        private async void TareasList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var tareas = e.Item as Models.Tareas;
            //Al tocar una tarea ir a la pagina mostrar tareas
            await Navigation.PushAsync(new MostrarTareasPage(tareas));
            return;
        }


        //private void BuscarBar_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    //var countriesSearched = Tareas.Where(c => c.Contains(BuscarBar.Text));
        //    //TareasList.ItemsSource = countriesSearched;

        //}

        private void TareasList_Refreshing(object sender, EventArgs e)
        {

        }

        private async void BuscarButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new BuscarTareaPage());

        }
    }
}