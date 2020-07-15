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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

  
        //Boton Cerrrar Sesion
        private async void CerrarButton_Clicked(object sender, EventArgs e)
        {

            bool res = await DisplayAlert("Advertencia",
                "Estás a punto de cerrar la sesion",
                "Aceptar", "Cancelar"); //Especisificacion de Diplay alert

            if (res == true) //Si la opcion es aceptar
            {

                await Navigation.PopToRootAsync();
                //await Navigation.PushAsync(new LoginPage());

            }
            else //Si la opcion es Cancelar
            {
                return; // simplemente regrese a la página y no Pasa nada.
            }

        }
    }
}
