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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void IngressButton_Clicked(object sender, EventArgs e)
        {
            /*En caso de tener campos vacios (Usrio y/o contraseña)
            alerta al usuario que debe llenarlos*/
            if (string.IsNullOrEmpty(PassEntry.Text) && string.IsNullOrEmpty(UserEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar sus credenciales", "Aceptar");
                PassEntry.Text = string.Empty;
                UserEntry.Focus();
                return;
            }

            /*En caso de tener campo usuario vacio
             alerta al usuario que debe llenarlo*/
            if (string.IsNullOrEmpty(UserEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar un usuario", "Aceptar");
                PassEntry.Text = string.Empty;
                UserEntry.Focus();
                return;
            }

            /*En caso de tener campo contraseña vacio
             alerta al usuario que debe llenarlo*/
            if (string.IsNullOrEmpty(PassEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar una contraseña", "Aceptar");

                PassEntry.Text = string.Empty;
                PassEntry.Focus();
                return;
            }

            //Cosumo ApiRest Formato Json

            //Validacion Login
            WaitActivity.IsRunning = true;
            string result;


            try
            {

                //Inhabilitar botones en pantalla
                IngressButton.IsEnabled = false;
                UserEntry.IsEnabled = false;
                PassEntry.IsEnabled = false;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9280"); //URl donde se publicó la Web
                string url = string.Format("/api/TareasX?username=" + UserEntry.Text + "&pasword=" + PassEntry.Text + ""); //URL API Parametros
                var response = await client.GetAsync(url);
                result = response.Content.ReadAsStringAsync().Result;

                //Habilitar botones en pantalla
                IngressButton.IsEnabled = true;
                UserEntry.IsEnabled = true;
                PassEntry.IsEnabled = true;


            }
            catch (Exception)
            {

                await DisplayAlert("Error", "No hay conexion, intente mas tarde", "Aceptar");
                IngressButton.IsEnabled = true;
                UserEntry.IsEnabled = true;
                PassEntry.IsEnabled = true;
                WaitActivity.IsRunning = false;
                return;
            }


            //Si no se encuentran registrpos con los usuarios especiicados por el usuario
            if (string.IsNullOrEmpty(result) || result == "0")
            {

                await DisplayAlert("Error", "Usuario o contraseña incorrecta", "Aceptar");
                WaitActivity.IsRunning = false;
                PassEntry.Text = string.Empty;
                PassEntry.Focus();
                return;

            }

            WaitActivity.IsRunning = false;
            ////Si se encuentran los registros especiicados por el usuario
            ///
            await Navigation.PushAsync(new InicioPage());
            PassEntry.Text = string.Empty;

            //    Navigation.InsertPageBefore(new UI_Tareas.InicioPage(), this);
            //    await Navigation.PopAsync();

            return;
        }
    }
}