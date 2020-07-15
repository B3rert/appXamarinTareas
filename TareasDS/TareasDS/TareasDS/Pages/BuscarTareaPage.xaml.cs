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
    public partial class BuscarTareaPage : ContentPage
    {
        public BuscarTareaPage()
        {
            InitializeComponent();
        }

        private async void BuscarButton_Clicked(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(BuscarEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar el ID  de Tarea", "Aceptar");
                BuscarEntry.Focus();
                return;
            }

            //Cosumo ApiRest, Buscar Tarea por ID

            WaitActivity.IsRunning = true;
            string result;

            try
            {
                //Inhabilitar botones en pantalla
                BuscarButton.IsEnabled = false;
                BuscarEntry.IsEnabled = false;


                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9280"); //URl donde se publicó la Web
                string url = string.Format("/api/MostrarTareas/ " + BuscarEntry.Text + " "); //URL API Parametros
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;

            }
            catch (Exception)
            {

                await DisplayAlert("Error", "No hay conexion, intente mas tarde", "Aceptar");
                BuscarButton.IsEnabled = true;
                BuscarEntry.IsEnabled = true;

                WaitActivity.IsRunning = false;
                return;
            }

            //Habilitar botones en pantalla
            BuscarButton.IsEnabled = true;
            BuscarEntry.IsEnabled = true;

            WaitActivity.IsRunning = false;

            var tarea = JsonConvert.DeserializeObject<Models.Tareas>(result);

            if (result == "null")
            {
                await DisplayAlert("Error", "La tarea no existe, vualva a intentarlo", "Aceptar");
                BuscarEntry.Text = string.Empty;
                BuscarEntry.Focus();
                return;
            }


            await Navigation.PushAsync(new MostrarTareasPage(tarea));

            BuscarEntry.Text = string.Empty;


        }
    }
}